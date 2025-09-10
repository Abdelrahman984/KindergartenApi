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
}
