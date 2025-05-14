namespace ModernDotNetApi.Tests.Repositories;

using Xunit;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using ModernDotNetApi.Infrastructure.Data;
using ModernDotNetApi.Infrastructure.Repositories;
using ModernDotNetApi.Domain.Entities;

public class EntryRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly ApiEntryRepository _repository;

    public EntryRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        _context = new AppDbContext(options);
        _repository = new ApiEntryRepository(_context);
    }

    [Fact]
    public async Task AddAsync_Should_Add_Entry()
    {
        // Arrange
        var entry = new ApiEntry { Name = "New", Description = "New Content" };

        // Act
        await _repository.AddAsync(entry);
        await _context.SaveChangesAsync();

        // Assert
        var dbEntry = await _context.ApiEntries.FirstOrDefaultAsync();
        dbEntry.Should().NotBeNull();
        dbEntry!.Name.Should().Be("New");
    }
}

