using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{

    public TeacherRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Teacher>> GetActiveTeachersAsync()
        => await _dbSet.Where(t => t.IsActive).ToListAsync();

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _dbSet
            .Include(t => t.Subject) // هنا نجيب المادة مع المدرس
            .ToListAsync();
    }

    public async Task<List<Teacher>> GetBulkTeachersByIdsAsync(List<Guid> ids)
    {
        return await _dbSet.Where(t => ids.Contains(t.Id)).ToListAsync();
    }

    public async Task UpdateBulkTeachersAsync(List<Teacher> teachers)
    {
        _dbSet.UpdateRange(teachers);
        await _context.SaveChangesAsync();
    }

    public async Task<Teacher?> GetByIdWithSubjectAsync(Guid teacherId)
    {
        return await _dbSet
            .Include(t => t.Subject)
            .FirstOrDefaultAsync(t => t.Id == teacherId);
    }

    public async Task<int> GetTotalCountAsync() =>
    await _dbSet.CountAsync();

    public async Task<int> GetActiveCountAsync() =>
        await _dbSet.CountAsync(t => t.IsActive);

    public async Task<int> GetInactiveCountAsync() =>
        await _dbSet.CountAsync(t => !t.IsActive);

    public async Task<int> GetWithSubjectsCountAsync() =>
        await _dbSet.CountAsync(t => t.SubjectId != null);

    public async Task<int> GetWithoutSubjectsCountAsync() =>
        await _dbSet.CountAsync(t => t.SubjectId == null);

}
