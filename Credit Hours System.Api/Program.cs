using CHS.BLL.Interfaces;
using CHS.BLL.Repositories;
using CHS.BLL.Services;
using CHS.DAL;
using CHS.DAL.Identity;
using Credit_Hours_System.Api.Extenstions;
using Credit_Hours_System.Api.CustomMiddleware;
using Credit_Hours_System.Api.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
namespace Credit_Hours_System.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog (initially without EF sink)
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting Credit Hours System API");

                // Replace default logging with Serilog
                builder.Host.UseSerilog();

                // Add services to the container.
                builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CreditHoursSystemContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<CreditHoursSystemIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            builder.Services.AddIdentityServices(builder.Configuration);

            //add token service
            builder.Services.AddScoped<ITokenService, TokenService>();

            var app = builder.Build();

            // Reconfigure Serilog with EF sink now that services are built
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.EntityFramework(app.Services)
                .CreateLogger();

            // Add Serilog request logging middleware (this should be early in the pipeline)
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000}ms";
                options.GetLevel = (httpContext, elapsed, ex) => ex != null
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

            // Configure the HTTP request pipeline.
            // Enable Swagger for all environments (Development and Production)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditHours API V1");
                c.RoutePrefix = "swagger"; // So Swagger is at /swagger/index.html
            });

            //use static files
            app.UseStaticFiles();

            //use cors
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            //  Custom logging middleware goes here
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            Log.Information("Credit Hours System API started successfully");
            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
        }
    }
}
