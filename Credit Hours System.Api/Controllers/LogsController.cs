using CHS.BLL;
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
        [EnableQuery(PageSize = 50)]
        public IQueryable<LogDto> Get()
        {
            return _logsRepository.GetAllLogDtos(); // this should return IQueryable<LogDto>
        }




        // GET: api/logs/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLogById(int id)
        //{
        //    var log = await _logsRepository.GetLogByIdAsync(id);
        //    if (log == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(log);
        //}
    }

}