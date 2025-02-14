using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingDTO;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryReadDto :ReadDto
{
    public List<SaplingReadDto>? SaplingReadDtos { get; set; }
    public string ImageUrl { get; set; }

}