using System.ComponentModel.DataAnnotations;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryUpdateDto:IUpdateDto
{
    [Required]
    [MinLength(3 , ErrorMessage= "Name must be at least 3 characters long")]
    public string? CategoryName { get; set; }
}