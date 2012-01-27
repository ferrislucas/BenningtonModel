using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Bennington.Core.List;

namespace ExampleFeatureManagement.Models
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
