using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

public class Entity : IEntity
  
{
    public Dictionary<string, Type> DtoTypes { get; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}