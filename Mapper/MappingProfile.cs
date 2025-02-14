using AutoMapper;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Models;

namespace SaplingStore.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // SAPLING
        CreateMap<SaplingReadDto, Sapling>().ForMember(dest => dest.SaplingCategory, opt => opt.MapFrom(src => src.SaplingCategoryBasicReadDto)).ForMember(dest=>dest.SaplingHeights,opt=> opt.MapFrom(src=>src.SaplingHeightReadDtos)); // SaplingReadDto'dan Sapling'e dönüşüm
        CreateMap<SaplingCreateDto, Sapling>(); // SaplingCreateDto'dan Sapling'e dönüşüm
        CreateMap<SaplingUpdateDto, Sapling>().ForMember(dest=>dest.SaplingHeights,opt=> opt.MapFrom(src=>src.SaplingHeightUpdateDtos)); // SaplingCategoryUpdateDto'dan Sapling'e dönüşüm
        CreateMap<Sapling, SaplingReadDto>().ForMember(dest => dest.SaplingCategoryBasicReadDto,
            opt => opt.MapFrom(src => src.SaplingCategory)).ForMember(dest=>dest.SaplingHeightReadDtos,opt=> opt.MapFrom(src=>src.SaplingHeights)); // Sapling'den SaplingReadDto'ya dönüşüm

        // SAPLING CATEGORY
        CreateMap<SaplingCategoryReadDto, SaplingCategory>()
            .ForMember(dest => dest.Saplings, opt => opt.MapFrom(src => src.SaplingReadDtos));
        CreateMap<SaplingCategory, SaplingCategoryReadDto>()
            .ForMember(dest => dest.SaplingReadDtos, opt => opt.MapFrom(src => src.Saplings));
        CreateMap<SaplingCategory, SaplingCategoryBasicReadDto>();
        CreateMap<SaplingCategoryBasicReadDto, SaplingCategory>();
        CreateMap<SaplingCategoryCreateDto, SaplingCategory>(); // SaplingCategoryCreateDto'dan SaplingCategoryRepository'ye dönüşüm
        CreateMap<SaplingCategoryUpdateDto, SaplingCategory>();
        
        
        CreateMap<SaplingHeight,SaplingHeightReadDto>().ForMember(dest => dest.SaplingName,opt => opt.MapFrom(src => src.Sapling!.Name));
        CreateMap<SaplingHeightReadDto, SaplingHeight>();
        CreateMap<SaplingHeightUpdateDto, SaplingHeight>();
        CreateMap<SaplingHeightCreateDto, SaplingHeight>();

        // Create the mapping
    }
}