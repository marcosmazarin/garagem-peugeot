using AllGaragem.Domain.Utils;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace AllGaragem.Domain.Entities
{       
    [Table("product")]
    public class Product : BaseModel, IHasId
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }// = Guid.NewGuid();

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("height")]
        public int Height { get; set; } // In centimeters

        [Column("width")]
        public int Width { get; set; } // In centimeters

        [Column("length")]
        public int Length { get; set; } // In centimeters

        [Column("weight")]
        public int Weight { get; set; } // In kilograms

        [Column("checkout_url")]
        public string CheckoutUrl { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }    
}
