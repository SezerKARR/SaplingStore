using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingCategoryRepository : ClassRepository<SaplingCategory>
{
    public SaplingCategoryRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }

    

    // public override async Task<SaplingCategory?> GetByIdAsync(int id)
    // {
    //     return await _context.Set<SaplingCategory>().Include(c => c.Saplings).FirstOrDefaultAsync(c => c.Id == id);
    // }
   
    protected override IQueryable<SaplingCategory> GetQueryAbleObject()
    {
        return _context.Set<SaplingCategory>().Include(c => c.Saplings).AsQueryable();
    }
    // public override async Task<List<SaplingCategory>> GetAllAsync(QueryObject queryObject)
    // {
    //     var saplingCategories = _context.Set<SaplingCategory>().Include
    //         (c => c.SaplingReadDtos).AsQueryable();
    //     if (!string.IsNullOrWhiteSpace(queryObject.Name))
    //     {
    //         saplingCategories =
    //             saplingCategories.Where(c => c.Name.ToLower().Contains(queryObject.Name.ToLower()));
    //     }
    //
    //     if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
    //     {
    //         if (queryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
    //         {
    //             saplingCategories = queryObject.IsDecSending
    //                 ? saplingCategories.OrderByDescending(s => s.Name)
    //                 : saplingCategories.OrderBy(s => s.Name);
    //         }
    //     }
    //
    //     return await saplingCategories.ToListAsync();
    // }

    
}