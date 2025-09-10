using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create;
using AllGaragem.Domain.Entities.Services.MZMSafeLink;
using AllGaragem.Domain.Interfaces.Persistence;
using AllGaragem.Domain.Interfaces.Services;
using ApiService.application.helpers;
using Mapster;

namespace AllGaragem.Application.ProductCheckout.UseCases.Product.Actions.Create
{
    public class CreateProductUseCase(IProductRepository productRepository, IMZMSafeLink mzmSafelink) : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMZMSafeLink _mzmSafelink = mzmSafelink;

        public async Task<UseCaseResult<CreateProductResponseDTO>> CreateProduct(CreateProductRequestDTO request)
        {
            try
            {
                string checkoutUrl = await GenerateCheckoutURL(request);

                if (checkoutUrl == string.Empty)
                    return UseCaseResult<CreateProductResponseDTO>.Failure("Erro ao gerar URL de checkout");

                GenerateSafeLinkResponseDTO checkoutUrlSafeLink = await _mzmSafelink.GenerateSafeLink(checkoutUrl);

                var newProduct = request.Adapt<Domain.Entities.Product>();
                newProduct.CheckoutUrl = checkoutUrlSafeLink.ShortenUrl;

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

            string price = (request.Price * 100).ToString("0");            

            string items = $"\"name\":\"{request.Description.Replace(" ", "+")}\",\"price\":{price},\"quantity\":1";            

            url = String.Format("https://checkout.infinitepay.io/{0}?items=[{{{1}}}]",
                Environment.GetEnvironmentVariable("INFINITEPAY_USER"),
                Uri.EscapeDataString(items));

            return Task.FromResult(url);
        }
    }
}
