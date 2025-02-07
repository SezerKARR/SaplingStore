using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingHeightRepository:ClassRepository<SaplingHeight>
{
    public SaplingHeightRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }

    protected override async void AddjustEntity(SaplingHeight entity)
    {
        
        try
        {
            entity.Sapling =
                await _context.Saplings.FirstOrDefaultAsync(c => c.Id == entity.SaplingId);
        }
        catch (Exception e)
        {
            throw; // TODO handle exception
        }
    }

    
    protected override IQueryable<SaplingHeight> GetQueryAbleObject()
    {
        return _context.Set<SaplingHeight>().Include(c => c.Sapling).AsQueryable();
    }
}