using SaplingStore.Helpers;

namespace SaplingStore.Interfaces;

using Abstract;

public interface IClassRepository<T> where T : class, IEntity
{
     Type GetCreateDto();
    Task<List<T>> GetAllAsync();
    Task<T?> GetBySlugAsync(string slug);
    Task<List<T>> GetAllAsync(QueryObject queryObject);
    Task<T?> GetByIdAsync(int? id);
    Task<T> CreateAsync(T entity);
    Task<T?> UpdateAsync<T1>(int id, T1 entity) where T1 : IUpdateDto;
    Task<T?> DeleteAsync(int id);
    Task<bool> EntityExists(int id);
     IQueryable<T> GetQueryAbleObject();
}