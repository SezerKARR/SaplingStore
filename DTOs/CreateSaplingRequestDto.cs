using SaplingStore.Interfaces;

namespace SaplingStore.DTOs;

public class CreateSaplingRequestDto:IDto
{
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}