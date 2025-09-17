using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories
{
    public class ClassSessionRepository : IClassSessionRepository
    {
        private readonly AppDbContext _context;

        public ClassSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassSession>> GetAllAsync()
        {
            return await _context.ClassSessions
                .Include(cs => cs.Classroom)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Subject)
                .ToListAsync();
        }

        public async Task<ClassSession> GetByIdAsync(Guid id)
        {
            return await _context.ClassSessions
                .Include(cs => cs.Classroom)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Subject)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task AddAsync(ClassSession entity)
        {
            await _context.ClassSessions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClassSession entity)
        {
            _context.ClassSessions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ClassSession entity)
        {
            _context.ClassSessions.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassSession>> GetByClassroomIdAsync(Guid classroomId)
        {
            return await _context.ClassSessions
                .Include(cs => cs.Classroom)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Subject)
                .Where(cs => cs.ClassroomId == classroomId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClassSession>> GetByTeacherIdAsync(Guid teacherId)
        {
            return await _context.ClassSessions
                .Include(cs => cs.Classroom)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Subject)
                .Where(cs => cs.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClassSession>> GetBySubjectIdAsync(Guid subjectId)
        {
            return await _context.ClassSessions
                .Include(cs => cs.Classroom)
                .Include(cs => cs.Teacher)
                .Include(cs => cs.Subject)
                .Where(cs => cs.SubjectId == subjectId)
                .ToListAsync();
        }
    }
}
