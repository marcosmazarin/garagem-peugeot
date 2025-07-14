using AllGaragem.Domain.Entities;
using AllGaragem.Domain.Interfaces;
using Supabase;

namespace AllGaragem.Infrastructure.Persistence
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Client dbContext) : base(dbContext)
        {
            dbContext.Postgrest.Options.Schema = "ProductCheckout";
        }
    }
}
