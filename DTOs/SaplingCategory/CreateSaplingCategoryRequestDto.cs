using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingCategory;

public class CreateSaplingCategoryRequestDto:IDto
{
    public string? CategoryName { get; set; }
}