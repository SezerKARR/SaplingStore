using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingCategory;

public class UpdateSaplingCategoryDto:IDto
{
    public string? CategoryName { get; set; }
    public List<Sapling> Saplings { get; set; } = new List<Sapling>();
}