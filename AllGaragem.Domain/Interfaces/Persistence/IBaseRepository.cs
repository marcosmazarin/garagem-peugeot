using Supabase.Postgrest.Models;

namespace AllGaragem.Domain.Interfaces.Persistence
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T?> GetByIdValue(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
