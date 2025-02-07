using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingHeightDto;

public class SaplingHeightCreateDto:ICreateDto
{
    public float Height { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingId { get; set; }
    public int SaplingMoney { get; set; }
}