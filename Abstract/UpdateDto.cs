using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

public class UpdateDto: IUpdateDto
{
    public string Name { get; set; }
}