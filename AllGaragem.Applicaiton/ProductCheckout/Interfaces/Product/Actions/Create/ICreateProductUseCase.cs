using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using ApiService.application.helpers;

namespace AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create
{
    public interface ICreateProductUseCase
    {
        Task<UseCaseResult<CreateProductResponseDTO>> CreateProduct(CreateProductRequestDTO request);
    }
}
