using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingReadDto:IReadDto
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
    public string? Description { get; set; }
    public int? SaplingCategoryId { get; set; }
    public SaplingCategoryBasicReadDto SaplingCategoryBasicReadDto { get; set; }= new SaplingCategoryBasicReadDto();
}