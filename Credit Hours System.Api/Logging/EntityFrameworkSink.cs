using CHS.DAL;
using CHS.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Serilog.Core;
using Serilog.Events;
using System.Text.Json;

namespace Credit_Hours_System.Api.Logging
{
    public class EntityFrameworkSink : ILogEventSink
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkSink(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Emit(LogEvent logEvent)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<CreditHoursSystemContext>();

                var log = new Log
                {
                    Message = logEvent.RenderMessage(),
                    MessageTemplate = logEvent.MessageTemplate?.Text,
                    Level = logEvent.Level.ToString(),
                    TimeStamp = logEvent.Timestamp,
                    Exception = logEvent.Exception?.ToString(),
                    Properties = SerializeProperties(logEvent.Properties),
                    LogEvent = null // We don't need to serialize the entire log event
                };

                // Extract custom properties
                if (logEvent.Properties.TryGetValue("RequestPath", out var requestPath))
                    log.RequestPath = requestPath?.ToString()?.Trim('"');

                if (logEvent.Properties.TryGetValue("RequestBody", out var requestBody))
                    log.RequestBody = requestBody?.ToString()?.Trim('"');

                if (logEvent.Properties.TryGetValue("ResponseBody", out var responseBody))
                    log.ResponseBody = responseBody?.ToString()?.Trim('"');

                if (logEvent.Properties.TryGetValue("UserId", out var userId))
                    log.UserId = userId?.ToString()?.Trim('"');

                if (logEvent.Properties.TryGetValue("ClientIp", out var clientIp))
                    log.ClientIp = clientIp?.ToString()?.Trim('"');

                if (logEvent.Properties.TryGetValue("ElapsedMilliseconds", out var elapsed))
                {
                    if (int.TryParse(elapsed?.ToString()?.Trim('"'), out var elapsedMs))
                        log.ElapsedMilliseconds = elapsedMs;
                }

                context.Logs.Add(log);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log to console as fallback to avoid infinite loop
                Console.WriteLine($"Failed to write log to database: {ex.Message}");
            }
        }

        private string SerializeProperties(IReadOnlyDictionary<string, LogEventPropertyValue> properties)
        {
            try
            {
                var dict = new Dictionary<string, object>();
                foreach (var kvp in properties)
                {
                    dict[kvp.Key] = kvp.Value?.ToString()?.Trim('"');
                }
                return JsonSerializer.Serialize(dict);
            }
            catch
            {
                return "{}";
            }
        }
    }
}