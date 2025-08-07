using CHS.DAL.Entites;

namespace CHS.BLL.Interfaces
{
    public interface ILogsRepository
    {
        //get all logs
        IQueryable<LogDto> GetAllLogDtos();
        //get log by id
        Task<Log> GetLogByIdAsync(int id);

    }
}
