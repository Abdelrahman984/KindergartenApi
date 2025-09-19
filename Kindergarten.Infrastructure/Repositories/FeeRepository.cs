using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Domain.Entities;
using Kindergarten.Domain.Enums;
using Kindergarten.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Infrastructure.Persistence.Repositories;

public class FeeRepository : GenericRepository<Fee>, IFeeRepository
{
    private readonly AppDbContext _context;

    public FeeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Fee>> GetAllAsync()
    {
        return await _context.Fees
            .Include(f => f.Student)
            .ThenInclude(s => s.Classroom)
            .Include(f => f.Parent)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fee>> GetFeesByStudentIdAsync(Guid studentId)
    {
        return await _context.Fees
            .Include(f => f.Student)
            .ThenInclude(s => s.Classroom)
            .Include(f => f.Parent)
            .Where(f => f.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fee>> GetFeesByParentIdAsync(Guid parentId)
    {
        return await _context.Fees
            .Include(f => f.Student)
            .ThenInclude(s => s.Classroom)
            .Include(f => f.Parent)
            .Where(f => f.ParentId == parentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fee>> GetOverdueFeesAsync()
    {
        return await _context.Fees
            .Include(f => f.Student)
            .ThenInclude(s => s.Classroom)
            .Include(f => f.Parent)
            .Where(f => f.Status == FeeStatus.Overdue)
            .ToListAsync();
    }

    public async Task<Fee?> GetByIdAsync(Guid id)
    {
        return await _context.Fees
            .Include(f => f.Student)
            .ThenInclude(s => s.Classroom)
            .Include(f => f.Parent)
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
