using Bennington.Cms.MenuSystem;
using ExampleFeatureManagement.Controllers;

namespace ExampleFeatureManagement
{
    public class ExampleFeatureManagementMenuSystemConfigurer : IMenuSystemConfigurer
    {
        public void Configure(IMenuRegistry menuRegistry)
        {
            menuRegistry.Add(new ActionSectionMenuItem("Example Feature", "Index", typeof(ExampleFeatureManagementController).Name.Replace("Controller", string.Empty)));
        }
    }
}
