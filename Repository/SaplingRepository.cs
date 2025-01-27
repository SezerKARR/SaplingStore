using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingRepository:ClassRepository<Sapling>
{
    public SaplingRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }

    protected override async void AddjustEntity(Sapling entity)
    {
        entity.SaplingCategory = await _context.SaplingCategories.FirstOrDefaultAsync(c => c.Id == entity.SaplingCategoryId);

    }

    protected override IQueryable<Sapling> GetQueryAbleObject()
    {
        return _context.Set<Sapling>().Include(c=>c.SaplingCategory).AsQueryable();
    }
}