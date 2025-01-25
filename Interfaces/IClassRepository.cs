using SaplingStore.Helpers;

namespace SaplingStore.Interfaces;

public interface IClassRepository<T> where T : IEntity
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(QueryObject queryObject);
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T?> UpdateAsync<T1>(int id,T1 entity) where T1 : IUpdateDto;
    Task<T?> DeleteAsync(int id);
    Task<bool> EntityExists(int id);
}