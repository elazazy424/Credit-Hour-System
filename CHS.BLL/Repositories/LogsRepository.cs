using CHS.BLL.Interfaces;
using CHS.DAL;
using CHS.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace CHS.BLL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly CreditHoursSystemContext _context;

        public LogsRepository(CreditHoursSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Log> GetAllLogs()
        {
            return _context.Logs
                .AsNoTracking() // Improves performance for read-only scenarios
                .AsQueryable();
        }

        // Get log by id
        public async Task<Log> GetLogByIdAsync(int id)
        {
            return await _context.Logs
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}