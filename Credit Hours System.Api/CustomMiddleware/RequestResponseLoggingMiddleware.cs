using System.Diagnostics;
using System.Text;
using Serilog;

namespace Credit_Hours_System.Api.CustomMiddleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var requestPath = context.Request.Path;
            var requestBody = await ReadRequestBodyAsync(context.Request);

            // Store the original response body stream
            var originalBodyStream = context.Response.Body;

            // Create a new memory stream for the response body
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            string responseText = string.Empty;

            try
            {
                // Call the next delegate/middleware in the pipeline
                await _next(context);

                sw.Stop();

                // Read the response
                responseText = await ReadResponseBodyAsync(responseBody);

                var clientIp = context.Connection.RemoteIpAddress?.ToString();
                var userId = context.User?.Identity?.IsAuthenticated == true
                    ? context.User.FindFirst("sub")?.Value ?? context.User.Identity.Name
                    : "Anonymous";

                Log
                 .ForContext("RequestPath", requestPath)
                 .ForContext("RequestBody", requestBody)
                 .ForContext("ResponseBody", responseText)
                 .ForContext("UserId", userId)
                 .ForContext("ClientIp", clientIp)
                 .ForContext("ElapsedMilliseconds", (int)sw.ElapsedMilliseconds)
                 .Information("HTTP {Method} {Path} responded {StatusCode} in {Elapsed}ms",
                 context.Request.Method,
                 requestPath,
                 context.Response.StatusCode,
                 sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                sw.Stop();

                Log.Error(ex,
                    "Unhandled exception at {Method} {Path} after {Elapsed}ms\nIP: {IP}\nRequestBody: {Request}",
                    context.Request.Method,
                    requestPath,
                    sw.ElapsedMilliseconds,
                    context.Connection.RemoteIpAddress?.ToString(),
                    requestBody);

                // Re-throw the exception to let it bubble up
                throw;
            }
            finally
            {
                // Copy the contents of the new memory stream (which contains the response) to the original stream
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            // Ensure the request body can be read multiple times
            request.EnableBuffering();

            // Read the request body
            request.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            // Reset the request body stream position for the next middleware
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
}