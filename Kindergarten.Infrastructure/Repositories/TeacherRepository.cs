using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teacher>> GetActiveTeachersAsync()
        => await _dbSet.Where(t => t.IsActive).ToListAsync();

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _context.Teachers
            .Include(t => t.Subject) // هنا نجيب المادة مع المدرس
            .ToListAsync();
    }

    public async Task<List<Teacher>> GetBulkTeachersByIdsAsync(List<Guid> ids)
    {
        return await _context.Teachers.Where(t => ids.Contains(t.Id)).ToListAsync();
    }

    public async Task UpdateBulkTeachersAsync(List<Teacher> teachers)
    {
        _context.Teachers.UpdateRange(teachers);
        await _context.SaveChangesAsync();
    }

    public async Task<Teacher?> GetByIdWithSubjectAsync(Guid teacherId)
    {
        return await _context.Teachers
            .Include(t => t.Subject)
            .FirstOrDefaultAsync(t => t.Id == teacherId);
    }
}
