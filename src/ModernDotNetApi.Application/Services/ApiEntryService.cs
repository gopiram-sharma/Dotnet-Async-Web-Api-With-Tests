using AutoMapper;
using ModernDotNetApi.Application.DTOs;
using ModernDotNetApi.Domain.Entities;
using ModernDotNetApi.Domain.Interfaces;

namespace ModernDotNetApi.Application.Services;

public class ApiEntryService : IApiEntryService
{
    private readonly IApiEntryRepository _repository;
    private readonly IMapper _mapper;

    public ApiEntryService(IApiEntryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ApiEntryDto>> GetAllAsync()
    {
        var entries = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ApiEntryDto>>(entries);
    }

    public async Task<ApiEntryDto?> GetByIdAsync(int id)
    {
        var entry = await _repository.GetByIdAsync(id);
        return entry is null ? null : _mapper.Map<ApiEntryDto>(entry);
    }

    public async Task AddAsync(ApiEntryDto dto)
    {
        var entry = _mapper.Map<ApiEntry>(dto);
        await _repository.AddAsync(entry);
        await _repository.SaveChangesAsync();
    }
}