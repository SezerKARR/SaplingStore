using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingReadDto : IReadDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Description  { get; set; }
    public List<SaplingHeightReadDto> SaplingHeightReadDtos { get; set; } = new List<SaplingHeightReadDto>();
    public int SaplingCategoryId { get; set; }
    public string ImageUrl { get; set; }
    public SaplingCategoryBasicReadDto SaplingCategoryBasicReadDto { get; set; } = new();
}