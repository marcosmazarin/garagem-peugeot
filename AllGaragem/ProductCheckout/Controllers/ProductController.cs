using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create;
using ApiService.application.helpers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AllGaragem.Api.ProductCheckout.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(ICreateProductUseCase createProductUseCase) : ControllerBase
    {
        private readonly ICreateProductUseCase _createProductUseCase = createProductUseCase;

        /// <summary>
        /// Criacao de um produto para checkout
        /// </summary>        
        [HttpPost]
        public async Task<ApiResponse<CreateProductResponseDTO>> CreateProduct([FromBody] CreateProductRequestDTO request, [FromServices] IValidator<CreateProductRequestDTO> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return new ApiResponse<CreateProductResponseDTO>(false, "Erro na validacao dos dados", validationResult.Errors);

            var response = await _createProductUseCase.CreateProduct(request);

            if (!response.IsSuccess)
                return new ApiResponse<CreateProductResponseDTO>(false, response.ErrorMessage!);
            
            return new ApiResponse<CreateProductResponseDTO>(true, "Produto criado com sucesso", response.Data!);
        }
    }
}