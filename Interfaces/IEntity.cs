namespace SaplingStore.Interfaces;

public interface IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}