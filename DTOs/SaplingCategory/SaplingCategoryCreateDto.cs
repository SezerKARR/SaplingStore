using System.ComponentModel.DataAnnotations;
using SaplingStore.Abstract;
using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingCategory;

public class SaplingCategoryCreateDto :CreateDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Min length is 3")]
    public string ImageUrl { get; set; }

}