using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

public  class ClassRepository<T> :IClassRepository<T> where T : class, IEntity
{
    private readonly AppDbContext _context;

    public ClassRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}