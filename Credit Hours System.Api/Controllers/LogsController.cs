using CHS.BLL.Interfaces;
using CHS.DAL.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Credit_Hours_System.Api.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class LogsController : ODataController
    {
        private readonly ILogsRepository _logsRepository;

        public LogsController(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository ?? throw new ArgumentNullException(nameof(logsRepository));
        }

        // GET: odata/logs
        [HttpGet]
        [EnableQuery(MaxTop = 1000, MaxExpansionDepth = 3, PageSize = 100)]
        public IQueryable<Log> GetAllLogs()
        {
            try
            {
                var logs = _logsRepository.GetAllLogs();
                
                // Add basic validation to prevent null issues
                return logs.Where(l => l.Id > 0);
            }
            catch (Exception ex)
            {
                // Log the error
                throw new InvalidOperationException($"Error retrieving logs: {ex.Message}", ex);
            }
        }

        // GET: odata/logs({id})
        [HttpGet("({id})")]
        [EnableQuery]
        public async Task<IActionResult> GetLogById(int id)
        {
            var log = await _logsRepository.GetLogByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // GET: odata/logs/$count
        [HttpGet("$count")]
        public async Task<IActionResult> GetLogsCount()
        {
            var count = _logsRepository.GetAllLogs().Count();
            return Ok(count);
        }

        // GET: odata/logs/test - Test endpoint for PowerBI
        [HttpGet("test")]
        [EnableQuery(MaxTop = 10)]
        public IQueryable<Log> GetTestLogs()
        {
            return _logsRepository.GetAllLogs().Take(10);
        }
    }
}