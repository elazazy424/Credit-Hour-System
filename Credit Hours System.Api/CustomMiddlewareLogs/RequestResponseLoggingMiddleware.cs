using CHS.DAL.Entites;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _scopeFactory;

    public RequestResponseLoggingMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
    {
        _next = next;
        _scopeFactory = scopeFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        var requestPath = context.Request.Path;
        var requestBody = await ReadRequestBodyAsync(context.Request);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);
            sw.Stop();

            var responseText = await ReadResponseBodyAsync(responseBody);

            var clientIp = context.Connection.RemoteIpAddress?.ToString();
            var userId = context.User?.Identity?.IsAuthenticated == true
                ? context.User.FindFirst("sub")?.Value ?? context.User.Identity.Name
                : "Anonymous";

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CHS.DAL.CreditHoursSystemContext>();

            var log = new Log
            {
                Message = $"HTTP {context.Request.Method} {requestPath} responded {context.Response.StatusCode} in {sw.ElapsedMilliseconds}ms",
                MessageTemplate = "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMilliseconds}ms",
                Level = "Information",
                TimeStamp = DateTimeOffset.UtcNow,
                Properties = $"{{\"Method\":\"{context.Request.Method}\",\"StatusCode\":{context.Response.StatusCode}}}",
                RequestPath = requestPath,
                RequestBody = requestBody,
                ResponseBody = responseText,
                UserId = userId,
                ClientIp = clientIp,
                ElapsedMilliseconds = (int)sw.ElapsedMilliseconds
            };

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            sw.Stop();

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CHS.DAL.CreditHoursSystemContext>();

            var errorLog = new Log
            {
                Message = ex.Message,
                MessageTemplate = "Unhandled exception at {Method} {Path} after {ElapsedMilliseconds}ms",
                Level = "Error",
                Exception = ex.ToString(),
                TimeStamp = DateTimeOffset.UtcNow,
                Properties = $"{{\"Method\":\"{context.Request.Method}\",\"Path\":\"{requestPath}\"}}",
                RequestPath = requestPath,
                RequestBody = requestBody,
                ResponseBody = string.Empty,
                UserId = "Anonymous",
                ClientIp = context.Connection.RemoteIpAddress?.ToString(),
                ElapsedMilliseconds = (int)sw.ElapsedMilliseconds
            };

            dbContext.Logs.Add(errorLog);
            await dbContext.SaveChangesAsync();

            throw; // Re-throw so ASP.NET Core handles the error properly
        }
        finally
        {
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }

    private async Task<string> ReadRequestBodyAsync(HttpRequest request)
    {
        request.EnableBuffering();
        request.Body.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Seek(0, SeekOrigin.Begin);
        return body;
    }

    private async Task<string> ReadResponseBodyAsync(MemoryStream responseBody)
    {
        responseBody.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(responseBody, Encoding.UTF8, leaveOpen: true);
        var text = await reader.ReadToEndAsync();
        responseBody.Seek(0, SeekOrigin.Begin);
        return text;
    }
}
