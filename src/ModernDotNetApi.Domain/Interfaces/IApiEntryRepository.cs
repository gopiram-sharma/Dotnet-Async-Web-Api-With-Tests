namespace ModernDotNetApi.Domain.Interfaces;

using ModernDotNetApi.Domain.Entities;

public interface IApiEntryRepository
{
    Task<IEnumerable<ApiEntry>> GetAllAsync();
    Task<ApiEntry?> GetByIdAsync(int id);
    Task AddAsync(ApiEntry entry);
    Task SaveChangesAsync();
}