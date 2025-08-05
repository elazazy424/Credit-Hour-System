

namespace CHS.DAL.Entites
{
    public class Log
    {
        public int Id { get; set; } // Primary key for the log entry
        public string Message { get; set; } //The rendered final log message with all values filled in.
        public string MessageTemplate { get; set; } //The original template used to create the message (e.g., User {UserId} logged in).
        public string Level { get; set; } //Log level, e.g., Information, Warning, Error, etc.
        public DateTimeOffset TimeStamp { get; set; } //When the log entry was created (with time zone info).
        public string Exception { get; set; } //	The full stack trace if an exception was logged, otherwise NULL.
        public string Properties { get; set; } //A JSON object of additional structured log data (e.g., UserId, Path, etc.).
        public string LogEvent { get; set; } //	Serialized log event object (internal Serilog format, rarely needed).

        // Custom fields
        public string RequestPath { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string UserId { get; set; }
        public string ClientIp { get; set; }
        public int? ElapsedMilliseconds { get; set; }
    }
}
