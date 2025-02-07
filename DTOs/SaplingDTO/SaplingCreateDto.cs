using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingCreateDto : ICreateDto
{
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    [MaxLength(80, ErrorMessage = "Max length is 30")]
    public string? Name { get; set; }


    public string? Description  { get; set; }
    public string ImageUrl { get; set; }
    [Required] public required int SaplingCategoryId { get; set; }
}