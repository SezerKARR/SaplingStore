using System.ComponentModel.DataAnnotations;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryCreateDto:ICreateDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Min length is 3")]
    [MaxLength(100, ErrorMessage = "Max length is 100")]
    public string? CategoryName { get; set; }
}