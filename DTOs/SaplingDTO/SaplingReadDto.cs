using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingReadDto:IReadDto
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
    public int? SaplingCategoryId { get; set; }
}