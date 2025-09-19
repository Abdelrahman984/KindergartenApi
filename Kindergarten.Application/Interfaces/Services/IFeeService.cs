using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IFeeService
{
    Task<FeeReadDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<FeeReadDto>> GetAllAsync();
    Task<IEnumerable<FeeReadDto>> GetByStudentIdAsync(Guid studentId);
    Task<IEnumerable<FeeReadDto>> GetByParentIdAsync(Guid parentId);
    Task<IEnumerable<FeeReadDto>> GetOverdueAsync();
    Task<FeeReadDto> CreateAsync(FeeCreateDto dto);
    Task MarkAsPaidAsync(Guid feeId);
    Task<FeeReadDto> ProcessPaymentAsync(Guid feeId, PayFeeDto dto);
    Task<bool> DeleteAsync(Guid id);
}
