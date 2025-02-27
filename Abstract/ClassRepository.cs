using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Abstract;

public abstract class ClassRepository<TEntity> : IClassRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _context;
    protected readonly IMapper _mapper;
    private readonly DbSet<TEntity> _dbSet;

    public abstract Type GetCreateDto();
    protected ClassRepository(AppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
        _dbSet=_context.Set<TEntity>();
    }
    // public virtual async Task<object> GetAllCreateAsync( ) {
    //     var all=await GetQueryAbleObject().ToListAsync();
    //     var mappedEntities=new List<object>();
    //     foreach (var entity in all)
    //     {
    //         mappedEntities.Add(_mapper.Map(entity, typeof(TEntity), entity.DtoTypes["CreateDto"]) ); ;
    //     }
    //     return mappedEntities;
    //     // Entity'nin createDto tipini al ve mapperı kullan
    // }
    
    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await GetQueryAbleObject().ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(QueryObject queryObject)
    {
        var query = GetQueryAbleObject();
        query = QueryableExtensions.ApplyFilter(query, queryObject.SortBy, queryObject.FilterBy);
        query = QueryableExtensions.ApplySorting(query, queryObject.SortBy, queryObject.IsDecSending);
        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return await query.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public  async Task<TEntity?> GetByIdAsync(int? id)
    {
        return await GetQueryAbleObject().FirstOrDefaultAsync(e=>e.Id==id);
    }

    public async Task<TEntity?> GetBySlugAsync(string slug)
    {
        return await GetQueryAbleObject().FirstOrDefaultAsync(e => e.Slug == slug);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {        
        Console.WriteLine(entity.Name);

        await AddjustEntity(entity);
        Console.WriteLine(entity.Id);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync<TUpdateDto>(int id, TUpdateDto dto) where TUpdateDto : IUpdateDto
    {
        var existing = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null) return null;
        _mapper.Map(dto, existing);
        await _context.SaveChangesAsync();
        return existing;
    }


    public virtual async Task<TEntity?> DeleteAsync(int id)
    {
        var model = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (model == null) return null;
        _context.Set<TEntity>().Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public virtual async Task<bool> EntityExists(int id)
    { 
        var a=await _dbSet.ToListAsync();
        Console.WriteLine((a.Count,a));
        return await _dbSet.AnyAsync(x => x.Id == id);
    }
    public abstract IQueryable<TEntity> GetQueryAbleObject();

    protected virtual async Task AddjustEntity(TEntity entity)
    {
    }
    

}