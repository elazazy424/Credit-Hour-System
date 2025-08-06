using CHS.DAL.Entites;

namespace CHS.BLL.Interfaces
{
    public interface ILogsRepository
    {
        IQueryable<Log> GetAllLogs();
        Task<Log> GetLogByIdAsync(int id);
    }
}