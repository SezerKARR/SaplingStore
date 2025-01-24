using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingDTO;

public class UpdateSaplingRequestDto:IDto
{
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}