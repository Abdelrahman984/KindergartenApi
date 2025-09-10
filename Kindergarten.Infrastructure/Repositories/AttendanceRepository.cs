using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Attendance>> GetByStudentAsync(Guid studentId)
        => await _dbSet.Where(a => a.StudentId == studentId).ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date)
        => await _dbSet.Where(a => a.Date == date.Date).ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByStudentAndRangeAsync(Guid studentId, DateTime fromDate, DateTime toDate)
        => await _dbSet
            .Where(a => a.StudentId == studentId && a.Date >= fromDate.Date && a.Date <= toDate.Date)
            .ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByRangeAsync(DateTime fromDate, DateTime toDate)
        => await _dbSet
            .Where(a => a.Date >= fromDate.Date && a.Date <= toDate.Date)
            .ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByStudentsAndRangeAsync(IEnumerable<Guid> studentIds, DateTime fromDate, DateTime toDate)
    {
        var idSet = studentIds.ToHashSet();
        return await _dbSet
            .Where(a => idSet.Contains(a.StudentId) && a.Date >= fromDate.Date && a.Date <= toDate.Date)
            .ToListAsync();
    }
}
