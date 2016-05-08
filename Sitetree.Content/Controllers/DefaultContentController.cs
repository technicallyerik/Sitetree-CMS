using System.Web.Mvc;

namespace Sitetree.Content.Controllers
{
    public class DefaultContentController : Controller
    {
        public ActionResult Index()
        {
            return new ContentResult {Content = "Hello World"};
        }
    }
}
