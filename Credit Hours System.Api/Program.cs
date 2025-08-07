using CHS.BLL.Interfaces;
using CHS.BLL.Repositories;
using CHS.BLL.Services;
using CHS.DAL;
using CHS.DAL.Identity;
using Credit_Hours_System.Api.Extenstions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using CHS.BLL;


namespace Credit_Hours_System.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // OData model builder
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<LogDto>("Logs");


            // Configure Serilog (Console Only)
            Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            try
            {
                Serilog.Log.Information("Starting Credit Hours System API");

                builder.Host.UseSerilog();


                // Add services to the container FOR ODATA
                builder.Services.AddControllers()
                 .AddOData(options =>
                 {
                     options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
                            .AddRouteComponents("odata", odataBuilder.GetEdmModel());
                 });



                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                // DB contexts
                builder.Services.AddDbContext<CreditHoursSystemContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddDbContext<CreditHoursSystemIdentityDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

                // DI registrations
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
                builder.Services.AddScoped<IStudentRepository, StudentRepository>();
                builder.Services.AddIdentityServices(builder.Configuration);
                builder.Services.AddScoped<ITokenService, TokenService>();
                builder.Services.AddScoped<ILogsRepository, LogsRepository>();

                var app = builder.Build();

                // Serilog request logging (for console/debugging)
                app.UseSerilogRequestLogging(options =>
                {
                    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000}ms";
                    options.GetLevel = (httpContext, elapsed, ex) =>
                        ex != null
                            ? LogEventLevel.Error
                            : httpContext.Response.StatusCode > 499
                                ? LogEventLevel.Error
                                : LogEventLevel.Information;

                    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                    {
                        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                        diagnosticContext.Set("RemoteIP", httpContext.Connection.RemoteIpAddress);
                        diagnosticContext.Set("UserAgent", httpContext.Request.Headers["User-Agent"].FirstOrDefault());

                        if (httpContext.User?.Identity?.IsAuthenticated == true)
                        {
                            diagnosticContext.Set("UserId", httpContext.User.FindFirst("sub")?.Value ?? httpContext.User.Identity.Name);
                        }
                    };
                });

                // Middleware & API pipeline
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditHours API V1");
                    c.RoutePrefix = "swagger";
                });

                app.UseStaticFiles();

                app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });

                //  Custom middleware that logs via EF
                app.UseMiddleware<RequestResponseLoggingMiddleware>();

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllers();

                Serilog.Log.Information("Credit Hours System API started successfully");
                app.Run();


            }
            catch (Exception ex)
            {
                Serilog.Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }
        }
    }

}