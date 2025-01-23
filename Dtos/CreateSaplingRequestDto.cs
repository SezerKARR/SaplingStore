namespace SaplingStore.Dtos;

public class CreateSaplingRequestDto
{
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}