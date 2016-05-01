using System.Web.Mvc;

namespace SiteTree.Web.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return new ContentResult {Content = "Admin panel"};
        }
    }
}