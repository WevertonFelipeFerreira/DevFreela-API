using DevFreela.Application.Queries.GetAllProjects;
using FluentValidation;
using System;

namespace DevFreela.Application.Validators
{
    public class GetAllProjectsQueryValidator : AbstractValidator<GetAllProjectsQuery>
    {
        public GetAllProjectsQueryValidator()
        {
            RuleFor(x => x.TotalCostHigherThan)
                .Must(IsDecimalValue)
                .WithMessage("Field must be float. Ex: 10.98");
        }

        private bool IsDecimalValue(string value)
        {
            return String.IsNullOrEmpty(value) || decimal.TryParse(value, out decimal _);
        }
    }
}
