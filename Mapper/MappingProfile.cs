using AutoMapper;
using SaplingStore.DTOs;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SaplingDto, Sapling>();
        CreateMap<CreateSaplingRequestDto, Sapling>();
        CreateMap<UpdateSaplingRequestDto, Sapling>();
        CreateMap<Sapling, SaplingDto>();
        CreateMap<SaplingCategory, SaplingCategoryDto>();
        CreateMap<CreateSaplingCategoryRequestDto, SaplingCategory>();
        CreateMap<SaplingCategoryDto, SaplingCategory>();
        CreateMap<UpdateSaplingRequestDto, SaplingCategory>();
        

        // Create the mapping
    }
   
   
}
