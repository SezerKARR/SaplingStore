using SaplingStore.Interfaces;

namespace SaplingStore.DTOs;

public class SaplingDto:IDto
{
    public int SaplingId { get; set; }
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}