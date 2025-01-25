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
        // SAPLING
        CreateMap<SaplingReadDto, Sapling>(); // SaplingReadDto'dan Sapling'e dönüşüm
        CreateMap<SaplingCreateDto, Sapling>(); // SaplingCreateDto'dan Sapling'e dönüşüm
        CreateMap<SaplingUpdateDto, Sapling>(); // SaplingCategoryUpdateDto'dan Sapling'e dönüşüm
        CreateMap<Sapling, SaplingReadDto>(); // Sapling'den SaplingReadDto'ya dönüşüm

        // SAPLING CATEGORY
        CreateMap<SaplingCategoryReadDto, SaplingCategory>();
        CreateMap<SaplingCategory, SaplingCategoryReadDto>()
            .ForMember(dest => dest.Saplings, opt => opt.MapFrom(src => src.Saplings));
        CreateMap<SaplingCategoryCreateDto, SaplingCategory>(); // SaplingCategoryCreateDto'dan SaplingCategoryRepository'ye dönüşüm
        CreateMap<SaplingCategoryUpdateDto, SaplingCategory>(); 

        // Create the mapping
    }
   
   
}
