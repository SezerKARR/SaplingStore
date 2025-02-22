namespace SaplingStore.Models;

using Abstract;
using DTOs.Image;
using Repository;

public class Image:Entity {
    public Dictionary<string, Type> DtoTypes { get; } = new Dictionary<string, Type>
    {
        { "CreateDto", typeof(ImageCreateDto) },
        { "UpdateDto", typeof(ImageUpdateDto) },
        { "ReadDto", typeof(ImageReadDto) }
    };
    public byte[] ImageData { get; set; }
    public string ContentType { get; set; }
    public DateTime UploadDate { get; set; }
}