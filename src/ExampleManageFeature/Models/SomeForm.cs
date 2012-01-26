using System.ComponentModel;
using System.Web.Mvc;
using Bennington.Cms.Metadata;
using Bennington.Core.List;

namespace ExampleManageFeature.Models
{
    public class SomeForm
    {
        [Hidden]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Name { get; set; }

        [HtmlEditor]
        [DisplayName("Some HTML")]
        public string SomeProperty { get; set; }
    }
}