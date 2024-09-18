using Domain.Entities;
using FluentValidation;

namespace Domain.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode estar vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                           .NotEmpty()
                           .WithMessage("O nome não pode estar vazio.")

                           .NotNull()
                           .WithMessage("O nome não pode ser nulo.")

                           .MinimumLength(3)
                           .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                           .MaximumLength(80)
                           .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Password)
                          .NotEmpty()
                          .WithMessage("A senha não pode estar vazia.")

                          .NotNull()
                          .WithMessage("A senha não pode ser nula.")

                          .MinimumLength(3)
                          .WithMessage("A senha deve ter no mínimo 3 caracteres.")

                          .MaximumLength(80)
                          .WithMessage("A senha deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Email)
                           .NotEmpty()
                           .WithMessage("O email não pode estar vazio.")

                           .NotNull()
                           .WithMessage("O email não pode ser nulo.")

                           .MinimumLength(9)
                           .WithMessage("O email deve ter no mínimo 9 caracteres.")

                           .MaximumLength(180)
                           .WithMessage("O email deve ter no máximo 180 caracteres.")

                           .Matches(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")
                           .WithMessage("O email informado não é valido.");

        }
    }
}
