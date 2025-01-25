using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Helpers;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingCategoryRepository:ClassRepository<SaplingCategory>
{
    public SaplingCategoryRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }

    public override async Task<List<SaplingCategory>> GetAllAsync()
    {
        
        return await _context.Set<SaplingCategory>().Include(c=>c.Saplings ).ToListAsync();
    }

    public override async Task<List<SaplingCategory>> GetAllAsync(QueryObject queryObject)
    {
        var stocks=  _context.Set<SaplingCategory>().Include
            (c=>c.Saplings ).AsQueryable();
        if (!string.IsNullOrEmpty(queryObject.CategoryName))
        {
            stocks = stocks.Where(c=>c.CategoryName.ToLower().Contains(queryObject.CategoryName.ToLower()));
        }
        
        return await stocks.ToListAsync();
    }

    public override async Task<SaplingCategory?> GetByIdAsync(int id)
    {
        return await _context.Set<SaplingCategory>().Include(c => c.Saplings).FirstOrDefaultAsync(c => c.Id == id);
    }
}