using Bennington.Cms.MenuSystem;

namespace HLLMRKPRJTRBTE.HomepageImageManagement
{
    public class MenuSystemConfigurer : IMenuSystemConfigurer
    {
        public void Configure(IMenuRegistry menuRegistry)
        {
            menuRegistry.Add(new ActionSectionMenuItem("Test", "Index", "Some"));
        }
    }
}
