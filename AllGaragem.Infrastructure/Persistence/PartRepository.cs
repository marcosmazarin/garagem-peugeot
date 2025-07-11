using AllGaragem.Domain.Entities.AllGaragem.Domain.Entities;
using AllGaragem.Domain.Interfaces;
using Supabase;

namespace AllGaragem.Infrastructure.Persistence
{
    public class PartRepository : BaseRepository<Product>, IPartRepository
    {
        public PartRepository(Client dbContext) : base(dbContext)
        {
            dbContext.Postgrest.Options.Schema = "ProductCheckout";
        }
    }
}
