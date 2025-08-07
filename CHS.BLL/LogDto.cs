namespace CHS.BLL
{
    public class LogDto
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? MessageTemplate { get; set; }
        public string? Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string? Exception { get; set; }
        public string? Properties { get; set; }
        public string? LogEvent { get; set; }
        public string? RequestPath { get; set; }
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }
        public string? UserId { get; set; }
        public string? ClientIp { get; set; }
        public int? ElapsedMilliseconds { get; set; }
    }
}
