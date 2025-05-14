namespace ModernDotNetApi.Infrastructure.Repositories;

using  ModernDotNetApi.Infrastructure.Data;
using  ModernDotNetApi.Domain.Entities;
using ModernDotNetApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ApiEntryRepository : IApiEntryRepository
{
    private readonly AppDbContext _context;

    public ApiEntryRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ApiEntry>> GetAllAsync() => await _context.ApiEntries.ToListAsync();
    public async Task<ApiEntry?> GetByIdAsync(int id) => await _context.ApiEntries.FindAsync(id);
    public async Task AddAsync(ApiEntry entry) => await _context.ApiEntries.AddAsync(entry);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}