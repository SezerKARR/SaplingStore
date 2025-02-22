namespace SaplingStore.Interfaces;

public interface IEntity
{
    Dictionary<string,Type> DtoTypes { get; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}