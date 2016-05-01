using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SiteTree.Web;
using SiteTree.Web.Routing;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "Start")]

namespace SiteTree.Web
{
    public class PreApplicationStart
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (CmsRoutingHttpModule));
        }
    }
}