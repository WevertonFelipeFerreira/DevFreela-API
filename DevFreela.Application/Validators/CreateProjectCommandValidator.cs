using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description field cannot be empty.")
                .MaximumLength(255)
                .WithMessage("Description field has a maximum length of 255 characters.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title field cannot be empty.")
                .MaximumLength(30)
                .WithMessage("Title has a maximum length of 30 characters.");
        }
    }
}
