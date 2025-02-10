using SaplingStore.Abstract;

namespace SaplingStore.DTOs.SaplingHeightDto;

public class SaplingHeightUpdateDto: UpdateDto
{
    public float Height { get; set; }
    public int SaplingMoney { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingId { get; set; }
}