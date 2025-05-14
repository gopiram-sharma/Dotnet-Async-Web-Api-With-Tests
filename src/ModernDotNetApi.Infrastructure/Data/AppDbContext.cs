using Microsoft.EntityFrameworkCore;
using ModernDotNetApi.Domain.Entities;

namespace ModernDotNetApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<ApiEntry> ApiEntries { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}