using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Abstract;

namespace SaplingStore.Models;

[Table("saplings")]
public class Sapling : Entity
{

    public string? Description  { get; set; }
    public List<SaplingHeight> SaplingHeights { get; set; } = new List<SaplingHeight>();
    public required int SaplingCategoryId { get; set; }
    public SaplingCategory? SaplingCategory { get; set; }
    public string ImageUrl { get; set; }
}
