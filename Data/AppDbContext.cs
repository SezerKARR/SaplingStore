using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Models;

namespace SaplingStore.Data;

public class AppDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
{
    public DbSet<Sapling> Saplings { get; set; }
    public DbSet<SaplingCategory> SaplingCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Sapling>().HasOne(s => s.SaplingCategory).WithMany(c => c.Saplings).HasForeignKey(s => s.SaplingCategoryId); 
        List<IdentityRole> roles =
        [
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },

            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }

        ];
        builder.Entity<IdentityRole>().HasData(roles);

    }
    
}
