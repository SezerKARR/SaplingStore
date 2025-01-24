using Microsoft.EntityFrameworkCore;
using SaplingStore.Models;

namespace SaplingStore.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<Sapling> Saplings { get; set; }
    public DbSet<SaplingCategory> SaplingCategories { get; set; }
    
}
