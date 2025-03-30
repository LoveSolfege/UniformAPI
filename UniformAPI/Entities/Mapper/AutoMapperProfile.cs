using AutoMapper;
using UniformAPI.Entities;
using UniformAPI.Entities.DTO;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Add this FIRST
        CreateMap<UniformCreateDto, Uniform>();
        
        // Then other mappings
        CreateMap<Uniform, UniformDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.UniformType.Type))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.UniformStatus.Status))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.UniformDepartment.Department));

        CreateMap<UniformType, UniformTypeDto>();
        CreateMap<UniformStatus, UniformStatusDto>();
        CreateMap<UniformDepartment, UniformDepartmentDto>();
    }
}