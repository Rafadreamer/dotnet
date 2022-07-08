using FluentValidation;

namespace Aplication.DTOs.Validations
{
    public class ProductDTOvalidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOvalidator()
        {

            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o coderp");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o nome do produto");

            RuleFor(x => x.Preco)
                .GreaterThan(0)
                .WithMessage("preco nao pode ser zero");

        }
    }
}
