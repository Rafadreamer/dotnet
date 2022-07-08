using FluentValidation;

namespace Aplication.DTOs.Validations
{
    public class PurchaseDTOvalidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOvalidator()
        {

            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o coderp");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o documento");

        }
    }
}
