using System.ComponentModel.DataAnnotations;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;

public class SaplingCategory:IEntity
{
    public int Id { get; set; }
    [Required]
    [MinLength(2, ErrorMessage ="Min length is 2")]
    [MaxLength(30, ErrorMessage ="Max length is 30")]
    public required string CategoryName { get; set; }
    public List<Sapling> Saplings { get; set; } = new List<Sapling>();
    
}