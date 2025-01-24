namespace SaplingStore.Interfaces;

public interface IClassRepository<T> where T : IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T?> UpdateAsync<T1>(int id,T1 entity) where T1 : IDto;
    Task<T?> DeleteAsync(int id);
    Task<bool> EntityExists(int id);
}