using Bennington.Cms.Metadata;
using Bennington.Core.List;
using FluentValidation;

namespace ExampleManageFeature.Models
{
    public class SomeControllerIndexViewModel
    {
        public SomeForm SomeForm { get; set; }
    }

    public class SomeForm
    {
        [Hidden]
        public string Id { get; set; }

        public string Name { get; set; }

        [HtmlEditor]
        public string SomeProperty { get; set; }
    }

    public class SomeFormValidator : AbstractValidator<SomeForm>
    {
        public SomeFormValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Field required");
        }
    }
}