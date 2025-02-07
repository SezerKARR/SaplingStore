using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Interfaces;

namespace SaplingStore.Models;
[Table("saplingHeights")]
public class SaplingHeight:IEntity
{
    public int Id { get; set; }
    public int SaplingId { get; set; }
    public Sapling? Sapling { get; set; }
    public float Height { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingMoney { get; set; }
}