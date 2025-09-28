using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class FeeService : IFeeService
{
    private readonly IFeeRepository _feeRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FeeService(IFeeRepository feeRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _feeRepository = feeRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<FeeReadDto?> GetByIdAsync(Guid id)
    {
        var fee = await _feeRepository.GetByIdAsync(id);
        return _mapper.Map<FeeReadDto>(fee);
    }

    public async Task<IEnumerable<FeeReadDto>> GetAllAsync()
    {
        var fees = await _feeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<FeeReadDto>>(fees);
    }

    public async Task<IEnumerable<FeeReadDto>> GetByStudentIdAsync(Guid studentId)
    {
        var fees = await _feeRepository.GetFeesByStudentIdAsync(studentId);
        return _mapper.Map<IEnumerable<FeeReadDto>>(fees);
    }

    public async Task<IEnumerable<FeeReadDto>> GetByParentIdAsync(Guid parentId)
    {
        var fees = await _feeRepository.GetFeesByParentIdAsync(parentId);
        return _mapper.Map<IEnumerable<FeeReadDto>>(fees);
    }

    public async Task<IEnumerable<FeeReadDto>> GetOverdueAsync()
    {
        var fees = await _feeRepository.GetOverdueFeesAsync();
        return _mapper.Map<IEnumerable<FeeReadDto>>(fees);
    }

    public async Task<FeeReadDto> CreateAsync(FeeCreateDto dto)
    {
        var fee = new Fee(dto.Amount, dto.DueDate, dto.StudentId, dto.ParentId);
        await _feeRepository.AddAsync(fee);
        return _mapper.Map<FeeReadDto>(fee);
    }

    public async Task MarkAsPaidAsync(Guid feeId)
    {
        var fee = await _feeRepository.GetByIdAsync(feeId);
        if (fee == null) throw new Exception("Fee not found");

        fee.MarkAsPaid(); // entity method to update PaymentDate & Status
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<FeeReadDto> ProcessPaymentAsync(Guid feeId, PayFeeDto dto)
    {
        var fee = await _feeRepository.GetByIdAsync(feeId);
        if (fee == null) throw new Exception("Fee not found");

        // هنا ممكن تربط مع API حقيقي (Vodafone/Instapay) أو تعمل mock
        bool success = true; // نتيجة الدفع

        if (success)
        {
            fee.MarkAsPaid(dto.TransactionId);
            await _unitOfWork.SaveChangesAsync();
        }

        return _mapper.Map<FeeReadDto>(fee);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _feeRepository.DeleteAsync(id);
        return true;
    }

    public async Task<FeeStatsDto> GetFeeStatsAsync()
        => await _feeRepository.GetFeeStatsAsync();
}
