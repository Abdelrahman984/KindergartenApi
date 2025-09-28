using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Interfaces.Repositories;

public interface IFeeRepository : IGenericRepository<Fee>
{
    Task<IEnumerable<Fee>> GetAllAsync();
    Task<Fee?> GetByIdAsync(Guid id);
    Task<IEnumerable<Fee>> GetFeesByStudentIdAsync(Guid studentId);
    Task<IEnumerable<Fee>> GetFeesByParentIdAsync(Guid parentId);
    Task<IEnumerable<Fee>> GetOverdueFeesAsync();
    Task<FeeStatsDto> GetFeeStatsAsync();
}
