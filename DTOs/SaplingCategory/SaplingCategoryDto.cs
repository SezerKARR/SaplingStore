using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryDto:IDto
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public List<Sapling> Saplings { get; set; } = new List<Sapling>();
}