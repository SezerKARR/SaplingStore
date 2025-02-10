using System.ComponentModel.DataAnnotations;
using SaplingStore.Abstract;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingCreateDto : CreateDto
{
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    [MaxLength(80, ErrorMessage = "Max length is 30")]


    public string? Description { get; set; }
    public string ImageUrl { get; set; }
    [Required] public required int SaplingCategoryId { get; set; }
}