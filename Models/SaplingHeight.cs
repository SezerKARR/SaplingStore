using System.ComponentModel.DataAnnotations.Schema;
using SaplingStore.Abstract;

namespace SaplingStore.Models;

using DTOs.SaplingHeightDto;

[Table("saplingHeights")]
public class SaplingHeight:Entity {
    
    public int SaplingId { get; set; }
    public Sapling? Sapling { get; set; }
    public float Height { get; set; }
    public string ImageUrl { get; set; }
    public int SaplingMoney { get; set; }
}