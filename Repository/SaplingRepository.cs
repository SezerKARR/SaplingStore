using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

using DTOs.SaplingDTO;

public class SaplingRepository(AppDbContext context, IMapper mapper) : ClassRepository<Sapling>(context, mapper) {
    

    protected override async Task AddjustEntity(Sapling entity)
    {
        try
        {
            entity.SaplingCategory =
                await _context.SaplingCategories.FirstOrDefaultAsync(c => c.Id == entity.SaplingCategoryId);
        }
        catch (Exception e)
        {
            throw; // TODO handle exception
        }
    }
    public override Type GetCreateDto() => typeof(SaplingCreateDto);
    // public override async Task<Sapling?> GetByIdAsync(int id)
    // {
    //     return await _context.Set<Sapling>().Include(c => c.SaplingCategory).Include(c=>c.SaplingHeights).FirstOrDefaultAsync(c => c.Id == id);
    // }
    public override IQueryable<Sapling> GetQueryAbleObject()
    {
        return _context.Set<Sapling>().Include(c => c.SaplingCategory).Include(c=>c.SaplingHeights).AsQueryable();
    }
}