using System;
using System.ComponentModel;
using Bennington.Core.List;

namespace ExampleFeature.Cms.Models
{
    public class ExampleFeatureListViewModel
    {
        [Hidden]
        public string Id { get; set; }
        
        public string Name { get; set; }

        [DisplayName("Last Modify Date")]
        public DateTime LastModifyDate { get; set; }

        [DisplayName("Last Modify By")]
        public string LastModifyBy { get; set; }
    }
}
