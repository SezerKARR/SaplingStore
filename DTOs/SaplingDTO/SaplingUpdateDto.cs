using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.DTOs.SaplingDTO;

public class SaplingUpdateDto : IUpdateDto
{
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    public string? Name { get; set; }
    public List<SaplingHeightUpdateDto> SaplingHeightUpdateDtos { get; set; } = new List<SaplingHeightUpdateDto>();
    public string? Description  { get; set; }
    public int? SaplingCategoryId { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
}

