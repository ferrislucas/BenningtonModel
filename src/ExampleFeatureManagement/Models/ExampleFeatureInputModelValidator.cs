using FluentValidation;

namespace ExampleFeatureManagement.Models
{
    public class ExampleFeatureInputModelValidator : AbstractValidator<ExampleFeatureInputModel>
    {
        public ExampleFeatureInputModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}