using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create
{
    public class CreateProductRequestDTO
    {
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
    }
}
