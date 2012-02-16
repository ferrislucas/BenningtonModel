using ExampleFeature.Cms.Models;
using FluentValidation;

namespace ExampleFeature.Cms.Validators
{
    public class ExampleFeatureInputModelValidator : AbstractValidator<ExampleFeatureInputModel>
    {
        public ExampleFeatureInputModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}