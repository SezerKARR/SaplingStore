using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

using System.ComponentModel.DataAnnotations;

public class CreateDto: ICreateDto
{
    [Required]public required int Id { get; set; }
    public string Name { get; set; }
}