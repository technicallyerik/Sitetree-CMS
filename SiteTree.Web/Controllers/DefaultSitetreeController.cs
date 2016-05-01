using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SiteTree.Web.Controllers
{
    public class DefaultSitetreeController : Controller
    {
        //[Route("{*catchall}")]
        public ActionResult Index(string path)
        {

            return new ContentResult {Content = "Hello World"};
        }
    }
}
