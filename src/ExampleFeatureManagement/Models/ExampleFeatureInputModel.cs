using System;
using System.ComponentModel;
using System.Web.Mvc;
using Bennington.Cms.Metadata;
using Bennington.Core.List;

namespace ExampleFeatureManagement.Models
{
    public class ExampleFeatureInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Some HTML")]
        [HtmlEditor]
        public string SomeProperty { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreateDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime LastModifyDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string LastModifyBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CreateBy { get; set; }
    }
}