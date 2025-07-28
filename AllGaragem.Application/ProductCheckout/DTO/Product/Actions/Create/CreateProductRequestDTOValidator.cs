using FluentValidation;

namespace AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create
{
    public class CreateProductRequestDTOValidator : AbstractValidator<CreateProductRequestDTO>
    {
        public CreateProductRequestDTOValidator() 
        { 
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Height).NotEmpty();
            RuleFor(x => x.Width).NotEmpty();
            RuleFor(x => x.Length).NotEmpty();
            RuleFor(x => x.Weight).NotEmpty();            
        }
    }
}
