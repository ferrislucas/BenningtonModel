using ExampleFeatureManagement.Models;
using FluentValidation;

namespace ExampleFeatureManagement.Validators
{
    public class ExampleFeatureInputModelValidator : AbstractValidator<ExampleFeatureInputModel>
    {
        public ExampleFeatureInputModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}