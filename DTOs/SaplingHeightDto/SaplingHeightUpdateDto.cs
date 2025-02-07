using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingHeightDto;

public class SaplingHeightUpdateDto:IUpdateDto
{
    public float Height { get; set; }
    public int SaplingMoney { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingId { get; set; }
}