using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid Email.");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Invalid Password.");

            RuleFor(n => n.FullName)
                .NotEmpty()
                .WithMessage("FullName cannot be empty.")
                .NotNull()
                .WithMessage("FullName cannot be null.");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
            return regex.IsMatch(password);
        }
    }
}
