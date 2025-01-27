using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryReadDto:IReadDto
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public List<SaplingReadDto>? SaplingReadDtos { get; set; } 
}