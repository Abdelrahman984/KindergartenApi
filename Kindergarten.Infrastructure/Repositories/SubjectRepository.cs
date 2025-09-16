using Kindergarten.Domain.Entities;
using Kindergarten.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Subject entity)
        {
            await _context.Subjects.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject entity)
        {
            _context.Subjects.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subject entity)
        {
            _context.Subjects.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
