using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Abstract;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;

[Table("SaplingCategory")]
public class SaplingCategory : Entity
{
    [Required]
    [MinLength(2, ErrorMessage = "Min length is 2")]
    [MaxLength(30, ErrorMessage = "Max length is 30")]
    public string ImageUrl { get; set; }

    public List<Sapling> Saplings { get; set; } = new();
}