using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;

namespace SaplingStore.Abstract;

public abstract class ClassRepository<T> :IClassRepository<T> where T : class,IEntity 
{
    protected readonly AppDbContext _context;
    protected readonly IMapper _mapping;

    protected ClassRepository(AppDbContext context, IMapper mapping)
    {
        _mapping = mapping;
        _context = context;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return  await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(QueryObject queryObject)
    {
        return  await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> UpdateAsync<TUpdateDto>(int id, TUpdateDto dto) where TUpdateDto : IUpdateDto
    {
        var existing = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null) return null;
        _mapping.Map(dto, existing);
        await _context.SaveChangesAsync();
        return existing;
    }

   

    public virtual async Task<T?> DeleteAsync(int id)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if(model == null) return null;
        _context.Set<T>().Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public virtual async Task<bool> EntityExists(int id)
    {
        return await _context.Set<T>().AnyAsync(x => x.Id == id);
    }
}