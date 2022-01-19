using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content field cannot be empty.")
                .NotNull()
                .WithMessage("Content cannot be null.")
                .MaximumLength(100)
                .WithMessage("Content field has a maximum length of 255 characters.");
        }
    }
}
