using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;

[Table("SaplingCategory")]
public class SaplingCategory : IEntity
{
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    [MaxLength(30, ErrorMessage = "Max length is 30")]
    public required string CategoryName { get; set; }
    public string ImageUrl { get; set; }

    public List<Sapling> Saplings { get; set; } = new();
    public int Id { get; set; }
}