using SaplingStore.Helpers;

namespace SaplingStore.Interfaces;

public interface IReadRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetBySlugAsync(string slug);
    Task<List<T>> GetAllAsync(QueryObject queryObject);
    Task<T?> GetByIdAsync(int? id);
    IQueryable<T> GetQueryAbleObject();
}
