using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.Models;

namespace SaplingStore.Repository;

public class SaplingCategoryRepository : ClassRepository<SaplingCategory>
{
    public SaplingCategoryRepository(AppDbContext context, IMapper mapping) : base(context, mapping)
    {
    }

    

    public override async Task<SaplingCategory?> GetByIdAsync(int id)
    {
        return await _context.Set<SaplingCategory>().Include(c => c.Saplings).FirstOrDefaultAsync(c => c.Id == id);
    }
    protected override IQueryable<SaplingCategory> GetQueryAbleObject()
    {
        return _context.Set<SaplingCategory>().Include(c => c.Saplings).AsQueryable();
    }
    // public override async Task<List<SaplingCategory>> GetAllAsync(QueryObject queryObject)
    // {
    //     var saplingCategories = _context.Set<SaplingCategory>().Include
    //         (c => c.SaplingReadDtos).AsQueryable();
    //     if (!string.IsNullOrWhiteSpace(queryObject.CategoryName))
    //     {
    //         saplingCategories =
    //             saplingCategories.Where(c => c.CategoryName.ToLower().Contains(queryObject.CategoryName.ToLower()));
    //     }
    //
    //     if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
    //     {
    //         if (queryObject.SortBy.Equals("CategoryName", StringComparison.OrdinalIgnoreCase))
    //         {
    //             saplingCategories = queryObject.IsDecSending
    //                 ? saplingCategories.OrderByDescending(s => s.CategoryName)
    //                 : saplingCategories.OrderBy(s => s.CategoryName);
    //         }
    //     }
    //
    //     return await saplingCategories.ToListAsync();
    // }

    
}