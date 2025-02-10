using SaplingStore.Abstract;

namespace SaplingStore.DTOs.SaplingHeightDto;

public class SaplingHeightReadDto: ReadDto
{
    public string ImageUrl { get; set; }
    public int SaplingMoney { get; set; }
    public int SaplingId { get; set; }
    public string SaplingName { get; set; }
    
}