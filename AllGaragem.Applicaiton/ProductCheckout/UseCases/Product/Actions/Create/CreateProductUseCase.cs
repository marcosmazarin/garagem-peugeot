using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create;
using AllGaragem.Domain.Interfaces;
using ApiService.application.helpers;
using Mapster;

namespace AllGaragem.Application.ProductCheckout.UseCases.Product.Actions.Create
{
    public class CreateProductUseCase(IProductRepository productRepository) : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<UseCaseResult<CreateProductResponseDTO>> CreateProduct(CreateProductRequestDTO request)
        {
            try
            {
                string checkoutUrl = await GenerateCheckoutURL(request);

                if (checkoutUrl == string.Empty)
                    return UseCaseResult<CreateProductResponseDTO>.Failure("Erro ao gerar URL de checkout");

                var newProduct = request.Adapt<AllGaragem.Domain.Entities.Product>();
                newProduct.CheckoutUrl = checkoutUrl;

                newProduct = await _productRepository.AddAsync(newProduct);

                var response = newProduct.Adapt<CreateProductResponseDTO>();

                return UseCaseResult<CreateProductResponseDTO>.Success(checkoutUrl, response);
            }
            catch (Exception e)
            {
                return UseCaseResult<CreateProductResponseDTO>.Failure($"Erro ao criar produto: {e.Message}");
            }
        }

        private Task<string> GenerateCheckoutURL(CreateProductRequestDTO request)
        {
            string url = $"https://checkout.infinitepay.io/{Environment.GetEnvironmentVariable("INFINITEPAY_USER")}?";

            url += "items=[{\"name\":\"" + request.Description.Replace(" ", "+") + "\",\"price\":" + request.Price.ToString() + ",\"quantity\":1}]";

            return Task.FromResult(url);
        }
    }
}
