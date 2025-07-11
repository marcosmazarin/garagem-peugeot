using AllGaragem.Domain.Utils;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace AllGaragem.Domain.Entities
{   
    namespace AllGaragem.Domain.Entities
    {
        [Table("product")]
        public class Product : BaseModel, IHasId
        {
            [PrimaryKey("id")]
            public Guid Id { get; set; } // UUID for unique identifier

            [Column("description")]
            public string Description { get; set; } = string.Empty;

            [Column("price")]
            public decimal Price { get; set; }

            [Column("height")]
            public decimal Height { get; set; } // In centimeters

            [Column("width")]
            public decimal Width { get; set; } // In centimeters

            [Column("length")]
            public decimal Length { get; set; } // In centimeters

            [Column("weight")]
            public decimal Weight { get; set; } // In kilograms

            [Column("checkout_url")]
            public string CheckoutUrl { get; set; } = string.Empty;

            [Column("created_at")]
            public DateTime CreatedAt { get; set; }
        }
    }

}
