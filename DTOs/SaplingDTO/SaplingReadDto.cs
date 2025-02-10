using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingReadDto :ReadDto, IReadDto
{

    public string? Description  { get; set; }
    public List<SaplingHeightReadDto> SaplingHeightReadDtos { get; set; } = new List<SaplingHeightReadDto>();
    public int SaplingCategoryId { get; set; }
    public string ImageUrl { get; set; }
    public SaplingCategoryBasicReadDto SaplingCategoryBasicReadDto { get; set; } = new();
}