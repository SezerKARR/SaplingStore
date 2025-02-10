using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

public class CreateDto: ICreateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}