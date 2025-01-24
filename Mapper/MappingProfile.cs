using AutoMapper;
using SaplingStore.DTOs;
using SaplingStore.DTOs.Sapling;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Sapling => SaplingDto
        // CreateMap<Sapling, SaplingDto>();
        // // CreateSaplingRequestDto => Sapling
        // CreateMap<CreateSaplingRequestDto, Sapling>();
        // CreateMap<UpdateSaplingRequestDto, Sapling>();
        CreateMap<IDto, IEntity>();
        CreateMap<IEntity, IDto>();
    }

   
}