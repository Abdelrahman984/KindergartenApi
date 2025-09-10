using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories;

public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(AppDbContext context) : base(context) { }

    public async Task<Classroom?> GetWithStudentsAsync(Guid id)
        => await _dbSet.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Student>> GetStudentsByTeacherIdAsync(Guid teacherId)
        => await _dbSet
            .Where(c => c.TeacherId == teacherId)
            .SelectMany(c => c.Students)
            .ToListAsync();
}
