using SaplingStore.Interfaces;

namespace SaplingStore.Models;

public class SaplingCategory:IEntity
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public List<Sapling> Saplings { get; set; } = new List<Sapling>();
    
}