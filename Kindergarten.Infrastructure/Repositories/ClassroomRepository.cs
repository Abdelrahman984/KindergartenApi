using Kindergarten.Application.DTOs;
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
            .Where(c => c.TeacherClassrooms.Any(tc => tc.TeacherId == teacherId))
            .SelectMany(c => c.Students)
            .ToListAsync();

    public async Task UpdateClassroomAsync(Classroom classroom)
    {
        _dbSet.Update(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var classroom = await _dbSet.FindAsync(id);
        if (classroom != null)
        {
            _dbSet.Remove(classroom);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> GetTotalCountAsync() =>
    await _dbSet.CountAsync();

    public async Task<double> GetAverageCapacityAsync() =>
        await _dbSet.AverageAsync(c => c.Capacity);

    public async Task<int> GetWithStudentsCountAsync() =>
        await _dbSet.CountAsync(c => c.Students.Any());

    public async Task<int> GetWithoutStudentsCountAsync() =>
        await _dbSet.CountAsync(c => !c.Students.Any());

    public async Task<IEnumerable<ClassroomStudentCountDto>> GetStudentCountsAsync()
    {
        return await _dbSet
            .Select(c => new ClassroomStudentCountDto
            {
                ClassroomId = c.Id,
                ClassroomName = c.Name,
                ClassroomCapacity = c.Capacity,
                StudentCount = c.Students.Count
            })
            .ToListAsync();
    }

    public async Task<List<Classroom>> GetAllWithRelationsAsync(CancellationToken ct = default)
    {
        return await _context.Classrooms
            .Include(c => c.Students)
            .Include(c => c.TeacherClassrooms)
                .ThenInclude(tc => tc.Teacher)
            .ToListAsync(ct);
    }
}
