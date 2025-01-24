using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingCategory;

public class CreateSaplingCategoryRequestDto:IDto
{
    public string? CategoryName { get; set; }
}