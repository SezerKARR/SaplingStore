namespace SaplingStore.Dtos;

public class SaplingDto
{
    public int SaplingId { get; set; }
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}