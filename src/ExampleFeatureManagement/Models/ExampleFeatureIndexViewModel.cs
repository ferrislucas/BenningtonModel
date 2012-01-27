using FluentValidation;

namespace ExampleFeatureManagement.Models
{
    public class ExampleFeatureIndexViewModel
    {
        public ExampleFeatureInputModel ExampleFeatureInputModel { get; set; }
    }

    public class ExampleFeatureInputModelValidator : AbstractValidator<ExampleFeatureInputModel>
    {
        public ExampleFeatureInputModelValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}