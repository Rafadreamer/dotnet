using System;
using FluentValidation;

namespace Aplication.DTOs.Validations
{
    public class PersonDTOvalidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOvalidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o documento");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o nome");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("informe o telefone");
        }
    }
}