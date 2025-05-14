using AutoMapper;
using ModernDotNetApi.Application.DTOs;
using ModernDotNetApi.Domain.Entities;

namespace ModernDotNetApi.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApiEntry, ApiEntryDto>().ReverseMap();
    }
}