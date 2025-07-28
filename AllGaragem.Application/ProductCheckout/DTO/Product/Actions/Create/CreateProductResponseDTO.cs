namespace AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create
{
    public class CreateProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public string CheckoutUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
