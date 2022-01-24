using DevFreela.Application.Commands.LoginUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class LoginUserCommandValidator: AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email field is mandatory.");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password field is mandatory.");
        }
    }
}
