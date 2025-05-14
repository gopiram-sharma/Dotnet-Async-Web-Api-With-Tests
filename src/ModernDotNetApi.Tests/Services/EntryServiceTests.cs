namespace ModernDotNetApi.Tests.Services;

using Xunit;
using Moq;
using FluentAssertions;
using ModernDotNetApi.Application.Services;
using ModernDotNetApi.Application.DTOs;
using ModernDotNetApi.Domain.Entities;
using AutoMapper;
using ModernDotNetApi.Domain.Interfaces;

public class EntryServiceTests
{
    private readonly ApiEntryService _service;
    private readonly Mock<IApiEntryRepository> _repoMock = new();
    private readonly IMapper _mapper;

    public EntryServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ApiEntry, ApiEntryDto>();
            cfg.CreateMap<ApiEntryDto, ApiEntry>();
        });
        _mapper = mapperConfig.CreateMapper();

        _service = new ApiEntryService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllEntriesAsync_Returns_EntryDto_List()
    {
        // Arrange
        var entries = new List<ApiEntry>
        {
            new ApiEntry { Id = 1, Name = "Test", Description = "Test Content" }
        };
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entries);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().HaveCount(1);
        result.First().Name.Should().Be("Test");
    }
}
