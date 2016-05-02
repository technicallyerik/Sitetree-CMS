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
        public ActionResult Index()
        {

            return new ContentResult {Content = "Hello World"};
        }
    }
}
