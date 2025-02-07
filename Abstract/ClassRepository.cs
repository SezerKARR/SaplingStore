using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Abstract;

public abstract class ClassRepository<TEntity> : IClassRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly AppDbContext _context;
    protected readonly IMapper _mapping;

    protected ClassRepository(AppDbContext context, IMapper mapping)
    {
        _mapping = mapping;
        _context = context;
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(QueryObject queryObject)
    {
        var query = GetQueryAbleObject();
        query = QueryableExtensions.ApplyFilter(query, queryObject.SortBy, queryObject.FilterBy);
        query = QueryableExtensions.ApplySorting(query, queryObject.SortBy, queryObject.IsDecSending);
        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return await query.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        AddjustEntity(entity);
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync<TUpdateDto>(int id, TUpdateDto dto) where TUpdateDto : IUpdateDto
    {
        var existing = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null) return null;
        _mapping.Map(dto, existing);
        await _context.SaveChangesAsync();
        return existing;
    }


    public virtual async Task<TEntity?> DeleteAsync(int id)
    {
        var model = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (model == null) return null;
        _context.Set<TEntity>().Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public virtual async Task<bool> EntityExists(int id)
    {
        return await _context.Set<TEntity>().AnyAsync(x => x.Id == id);
    }

    protected abstract IQueryable<TEntity> GetQueryAbleObject();

    protected virtual  void AddjustEntity(TEntity entity)
    {
    }

}