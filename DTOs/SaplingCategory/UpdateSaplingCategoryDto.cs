using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingCategory;

public class UpdateSaplingCategoryDto:IDto
{
    public string? CategoryName { get; set; }
}