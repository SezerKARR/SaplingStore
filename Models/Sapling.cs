using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;
[Table("saplings")]
public class Sapling:IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public List<float> Heights { get; set; } = new List<float>();
    public required int SaplingCategoryId { get; set; }
    public SaplingCategory? SaplingCategory { get; set; }

}