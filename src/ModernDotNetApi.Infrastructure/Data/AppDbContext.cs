using Microsoft.EntityFrameworkCore;
using ModernDotNetApi.Domain.Entities;

namespace ModernDotNetApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<ApiEntry> ApiEntries { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ApiEntry>().HasData(
        new ApiEntry
        {
            Id = 1,
            Name = "openai -1",
            Description = "openai api - 1",
            Url = "http://openai.org/1",
            Category = "open source"
        },
        new ApiEntry
        {
            Id = 2,
            Name = "openai -2",
            Description = "openai api - 2",
            Url = "http://openai.org/2",
            Category = "open source"
        },
        new ApiEntry
        {
            Id = 3,
            Name = "openai -3",
            Description = "openai api - 3",
            Url = "http://openai.org/3",
            Category = "open source"
        },
        new ApiEntry
        {
            Id = 4,
            Name = "openai -4",
            Description = "openai api - 4",
            Url = "http://openai.org/4",
            Category = "open source"
        },
        new ApiEntry
        {
            Id = 5,
            Name = "openai -5",
            Description = "openai api - 5",
            Url = "http://openai.org/5",
            Category = "open source"
        }
    );
}
}