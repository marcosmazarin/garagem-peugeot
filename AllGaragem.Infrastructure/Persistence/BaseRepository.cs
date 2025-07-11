using AllGaragem.Domain.Interfaces;
using AllGaragem.Domain.Utils;
using Supabase;
using Supabase.Postgrest.Models;

namespace AllGaragem.Infrastructure.Persistence
{
    public class BaseRepository<T>(Client dbContext) : IBaseRepository<T> where T : BaseModel, IHasId, new()
    {
        protected readonly Client _dbContext = dbContext;
        public async Task<T?> AddAsync(T entity)
        {
            var result = await _dbContext
                .From<T>()
                .Insert(entity, new Supabase.Postgrest.QueryOptions { Returning = Supabase.Postgrest.QueryOptions.ReturnType.Representation });

            return result.Model;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.From<T>().Delete(new T { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _dbContext.From<T>().Get();

            return response.Models;
        }

        public async Task<T?> GetByIdValue(Guid id)
        {
            var result = await _dbContext.From<T>().Where(x => x.Id == id).Get();

            return result.Model;
        }

        public async Task UpdateAsync(T entity)
        {
            await _dbContext.From<T>().Update(entity);
        }
    }
}
