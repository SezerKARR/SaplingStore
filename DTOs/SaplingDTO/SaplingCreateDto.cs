using System.ComponentModel.DataAnnotations;
using SaplingStore.Interfaces;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingCreateDto:ICreateDto
{
    [Required]
    [MinLength(2, ErrorMessage ="Min length is 2")]
    [MaxLength(30, ErrorMessage ="Max length is 30")]
    public string? Name { get; set; } 
    [MaxLength(100, ErrorMessage ="Max length is 100")]
    public List<float> Heights { get; set; } = new List<float>();
    public string? Description { get; set; }
    [Required]
    public required int SaplingCategoryId { get; set; }
}