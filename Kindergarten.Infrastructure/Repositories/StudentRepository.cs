using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }

    public override async Task<Student?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _dbSet
            .Include(s => s.Parent)
            .Include(s => s.Classroom)
            .FirstOrDefaultAsync(s => s.Id == id, ct);

    public async Task<IEnumerable<Student>> GetActiveStudentsAsync()
        => await _dbSet.Where(s => s.IsActive).ToListAsync();

    public async Task<int> GetStudentsCountAsync() =>
         await _context.Students.CountAsync();

    public async Task<IEnumerable<Student>> GetByFilterAsync(Guid? classroomId, string? name, bool? isActive)
    {
        var query = _dbSet
            .Include(s => s.Parent)
            .Include(s => s.Classroom)
            .AsQueryable();

        if (classroomId.HasValue)
            query = query.Where(s => EF.Property<Guid?>(s, "ClassroomId") == classroomId.Value);

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(s => EF.Functions.Like(s.FullName, $"%{name}%"));

        if (isActive.HasValue)
            query = query.Where(s => s.IsActive == isActive.Value);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Student>> GetByClassroomIdAsync(Guid classroomId)
        => await _dbSet
            .Include(s => s.Parent)
            .Include(s => s.Classroom)
            .Where(s => EF.Property<Guid?>(s, "ClassroomId") == classroomId)
            .ToListAsync();

    public async Task<IEnumerable<Student>> GetByParentIdAsync(Guid parentId)
        => await _dbSet
            .Include(s => s.Parent)
            .Include(s => s.Classroom)
            .Where(s => EF.Property<Guid?>(s, "ParentId") == parentId)
            .ToListAsync();
}
