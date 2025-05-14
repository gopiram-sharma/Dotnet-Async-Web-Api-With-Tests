namespace ModernDotNetApi.Application.Services;

using ModernDotNetApi.Application.DTOs;

public interface IApiEntryService
{
    Task<IEnumerable<ApiEntryDto>> GetAllAsync();
    Task<ApiEntryDto?> GetByIdAsync(int id);
    Task AddAsync(ApiEntryDto dto);
}