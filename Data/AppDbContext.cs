using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Models;

namespace SaplingStore.Data;

public class AppDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
{
    public DbSet<Sapling> Saplings { get; set; }
    public DbSet<SaplingCategory> SaplingCategories { get; set; }
    public DbSet<SaplingHeight> SaplingHeights { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<SaplingHeight>()
            .HasOne(s => s.Sapling)
            .WithMany(h => h.SaplingHeights)
            .HasForeignKey(s => s.SaplingId);

        builder.Entity<Sapling>().HasOne(s => s.SaplingCategory).WithMany(c => c.Saplings)
            .HasForeignKey(s => s.SaplingCategoryId);
        List<IdentityRole> roles =
        [
            new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },

            new()
            {
                Name = "User",
                NormalizedName = "USER"
            }
        ];
        builder.Entity<IdentityRole>().HasData(roles);
    }
}