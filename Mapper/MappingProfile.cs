using AutoMapper;
using SaplingStore.DTOs;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Sapling => SaplingDto
        CreateMap<Sapling, SaplingDto>();
        // CreateSaplingRequestDto => Sapling
        CreateMap<CreateSaplingRequestDto, Sapling>();
        CreateMap<UpdateSablingRequestDto, Sapling>();
    }

   
}