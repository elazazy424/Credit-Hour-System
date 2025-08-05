using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace Credit_Hours_System.Api.Logging
{
    public static class SerilogExtensions
    {
        public static LoggerConfiguration EntityFramework(
            this LoggerSinkConfiguration loggerConfiguration,
            IServiceProvider serviceProvider,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose)
        {
            return loggerConfiguration.Sink(new EntityFrameworkSink(serviceProvider), restrictedToMinimumLevel);
        }
    }
}