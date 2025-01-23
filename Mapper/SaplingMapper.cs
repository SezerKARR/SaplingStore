using SaplingStore.Dtos;
using SaplingStore.Models;

namespace SaplingStore.Mapper;

public static class SaplingMapper
{
    public static SaplingDto ToSaplingDto(this Sapling saplingModel)
    {
        return new SaplingDto()
        {
            SaplingId = saplingModel.Id,
            Name = saplingModel.Name,
            Heights = saplingModel.Heights,
        };
    }
    public static Sapling ToSaplingFromCreateDto(this CreateSaplingRequestDto saplingRequestDto)
    {
        return new Sapling()
        {
            Name = saplingRequestDto.Name,
            Heights = saplingRequestDto.Heights,
        };
    }
}