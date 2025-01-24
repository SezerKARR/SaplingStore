using SaplingStore.Interfaces;

namespace SaplingStore.DTOs;

public class UpdateSablingRequestDto:IDto
{
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}