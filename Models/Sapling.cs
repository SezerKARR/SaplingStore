using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Abstract;

namespace SaplingStore.Models;

using DTOs.SaplingDTO;
using Interfaces;

[Table("saplings")]
public class Sapling : Entity {

    public Dictionary<string, Type> DtoTypes { get; } = new Dictionary<string, Type>
    {
        { "CreateDto", typeof(SaplingCreateDto) },
        { "UpdateDto", typeof(SaplingUpdateDto) },
        { "ReadDto", typeof(SaplingReadDto) }
    };
    public string? Description  { get; set; }
    public List<SaplingHeight> SaplingHeights { get; set; } = new List<SaplingHeight>();
    public required int SaplingCategoryId { get; set; }
    public SaplingCategory? SaplingCategory { get; set; }
    public string ImageUrl { get; set; }
    
}
