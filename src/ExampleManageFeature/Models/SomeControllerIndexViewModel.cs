using FluentValidation;

namespace ExampleManageFeature.Models
{
    public class SomeControllerIndexViewModel
    {
        public SomeForm SomeForm { get; set; }
    }

    public class SomeFormValidator : AbstractValidator<SomeForm>
    {
        public SomeFormValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}