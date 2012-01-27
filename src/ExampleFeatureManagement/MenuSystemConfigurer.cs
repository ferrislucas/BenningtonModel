using Bennington.Cms.MenuSystem;

namespace ExampleFeatureManagement
{
    public class MenuSystemConfigurer : IMenuSystemConfigurer
    {
        public void Configure(IMenuRegistry menuRegistry)
        {
            menuRegistry.Add(new ActionSectionMenuItem("Example Feature", "Index", "ExampleFeatureManagement"));
        }
    }
}
