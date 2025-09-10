using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class ParentService : IParentService
{
    private readonly IParentRepository _parentRepository;
    private readonly IMapper _mapper;

    public ParentService(IParentRepository parentRepository, IMapper mapper)
    {
        _parentRepository = parentRepository;
        _mapper = mapper;
    }

    public async Task<ParentReadDto> CreateParentAsync(ParentCreateDto dto)
    {
        var parent = _mapper.Map<Parent>(dto);
        await _parentRepository.AddAsync(parent);
        return _mapper.Map<ParentReadDto>(parent);
    }

    public async Task<IEnumerable<ParentReadDto>> GetAllAsync()
    {
        var parents = await _parentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ParentReadDto>>(parents);
    }

    public async Task<ParentReadDto?> GetByIdAsync(Guid id)
    {
        var parent = await _parentRepository.GetByIdAsync(id);
        return _mapper.Map<ParentReadDto?>(parent);
    }

    public async Task UpdateInfoAsync(Guid id, ParentUpdateDto dto)
    {
        var parent = await _parentRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Parent not found");

        _mapper.Map(dto, parent);
        await _parentRepository.UpdateAsync(parent);
    }
    public async Task<ParentReadDto?> GetByPhoneAsync(string phoneNumber)
    {
        var parent = await _parentRepository.GetByPhoneAsync(phoneNumber);
        return _mapper.Map<ParentReadDto?>(parent);
    }
    public async Task<ParentReadDto?> GetWithChildrenAsync(Guid parentId)
    {
        var parent = await _parentRepository.GetWithChildrenAsync(parentId);
        return _mapper.Map<ParentReadDto?>(parent);
    }
}
