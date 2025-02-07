using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingHeightDto;

public class SaplingHeightReadDto:IReadDto
{
    public int Id { get; set; }
    public float Height { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingMoney { get; set; }
    public int SaplingId { get; set; }
    public string SaplingName { get; set; }
    
}