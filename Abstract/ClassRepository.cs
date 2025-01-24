using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;

namespace SaplingStore.Abstract;

public  class ClassRepository<T> :IClassRepository<T> where T : class, IEntity
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapping;
    public ClassRepository(AppDbContext context, IMapper mapping)
    {
        _mapping = mapping;
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return  await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> UpdateAsync<T1>(int id, T1 dto) where T1 : IDto
    {
        var existing = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null) return null;
        _mapping.Map(dto, existing);
        await _context.SaveChangesAsync();
        return existing;
    }

   

    public async Task<T?> DeleteAsync(int id)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if(model == null) return null;
        _context.Set<T>().Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> EntityExists(int id)
    {
        return await _context.Set<T>().AnyAsync(x => x.Id == id);
    }
}