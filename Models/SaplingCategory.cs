using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Abstract;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;

using DTOs.SaplingCategory;
using DTOs.SaplingDTO;

[Table("SaplingCategory")]
public class SaplingCategory : Entity {
    public Dictionary<string, Type> DtoTypes { get; } = new Dictionary<string, Type>
    {
        { "CreateDto", typeof(SaplingCategoryCreateDto) },
        { "UpdateDto", typeof(SaplingCategoryUpdateDto) },
        { "ReadDto", typeof(SaplingCategoryReadDto) }
    };
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    public string ImageUrl { get; set; }

    public List<Sapling> Saplings { get; set; } = new();
}