using System.Web.Mvc;
using Sitetree.Content.Models;

namespace Sitetree.Content.Controllers
{
    public class DefaultContentController : Controller
    {
        public ActionResult Index(Page page)
        {
            return new ContentResult {Content = "Hello World " + page.Id };
        }
    }
}
