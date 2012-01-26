using System.Web.Mvc;
using System.Web.UI.WebControls;
using Bennington.Content.Attributes;

namespace SampleContentWebsite.Controllers
{
    [Engine("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }

    public class NewsroomListItem
    {
        
    }
}
