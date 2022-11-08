using Confitec.Services.Handles.Users.Commands;
using FluentValidation;

namespace Confitec.Services.Handles.Users.Validators
{
    public sealed class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserValidator()
        {
            RuleFor(u => u.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")
                .MaximumLength(255)
                .WithMessage("O nome não pode ter mais que 255 caracteres");

            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O sobrenome não pode ser vazio.")
                .MaximumLength(255)
                .WithMessage("O sobrenome não pode ter mais que 255 caracteres");

            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")
                .EmailAddress()
                .WithMessage("O email informado não é válido.")
                .MaximumLength(255)
                .WithMessage("O email não pode ter mais que 255 caracteres");

            RuleFor(u => u.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")
                .Custom((prop, context) =>
                {
                    if (prop.Value.Date > System.DateTime.UtcNow.Date)
                        context.AddFailure("Data de nascimento não pode ser maior que a data de hoje");
                }).When(x => x.BirthDate.HasValue);

            RuleFor(u => u.Schooling)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Escolaridade não pode ser vazio.");
        }
    }
}
