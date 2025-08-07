using CHS.BLL.Interfaces;
using CHS.DAL;
using CHS.DAL.Entites;
using System.Text.Json;


namespace CHS.BLL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly CreditHoursSystemContext _context;


        public LogsRepository(CreditHoursSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<LogDto> GetAllLogDtos()
        {
            /* var logs = _context.Logs.ToList(); */// materialize into memory

            return _context.Logs.Select(log => new LogDto
            {
                Id = log.Id,
                Message = log.Message,
                MessageTemplate = log.MessageTemplate,
                Level = log.Level,
                TimeStamp = log.TimeStamp,
                Exception = log.Exception,
                Properties = ConvertJsonToSafeString(log.Properties, 1000),
                LogEvent = log.LogEvent,
                RequestPath = log.RequestPath,
                RequestBody = ConvertJsonToSafeString(log.RequestBody, 1000),
                ResponseBody = ConvertJsonToSafeString(log.ResponseBody, 1000),
                UserId = log.UserId,
                ClientIp = log.ClientIp,
                ElapsedMilliseconds = log.ElapsedMilliseconds
            }); // OData needs IQueryable, so convert back
        }

        private static string ConvertJsonToSafeString(string json, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                var parsed = JsonDocument.Parse(json);
                var result = JsonSerializer.Serialize(parsed.RootElement);

                return result.Length > maxLength ? result.Substring(0, maxLength) + "..." : result;
            }
            catch
            {
                // Fallback if JSON is invalid
                return json.Length > maxLength ? json.Substring(0, maxLength) + "..." : json;
            }
        }




        // Get log by id
        public async Task<Log> GetLogByIdAsync(int id)
        {
            return await _context.Logs.FindAsync(id);
        }
    }

}