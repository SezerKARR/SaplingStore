using SaplingStore.Interfaces;

namespace SaplingStore.Models;

public class Sapling:IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public List<float> Heights { get; set; } = new List<float>();
}