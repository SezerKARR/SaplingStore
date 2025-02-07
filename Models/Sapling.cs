using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;

[Table("saplings")]
public class Sapling : IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description  { get; set; }
    public List<SaplingHeight> SaplingHeights { get; set; } = new List<SaplingHeight>();
    public required int SaplingCategoryId { get; set; }
    public SaplingCategory? SaplingCategory { get; set; }
    public string ImageUrl { get; set; }
}
