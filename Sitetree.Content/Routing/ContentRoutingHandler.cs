using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitetree.Content.DataAccess.Repositories;
using Sitetree.Content.Extensions;
using Sitetree.Content.Models;
using Sitetree.Core.DataAccess.Repositories;
using Sitetree.Core.Routing.Interfaces;

namespace Sitetree.Content.Routing
{
    [Export(typeof (IRequestHandler))]
    public class ContentRoutingHandler : IRequestHandler
    {
        public int Order => 50;

        public bool HandleRequest(HttpContext context)
        {
            var request = context.Request;
            var requestContext = request.RequestContext;

            var pathParts = GetPathPartsFromRequestContext(requestContext);
            var page = GetPageFromPathParts(requestContext, pathParts);
            if (page != null)
            {
                ExecuteControllerForPage(requestContext, page);
                return true;
            }
            return false;
        }

        private List<string> GetPathPartsFromRequestContext(RequestContext requestContext)
        {
            var path = requestContext.RouteData.Values["path"] as string;
            path = path?.TrimEnd('/');
            var pathParts = path?.Split('/').ToList() ?? new List<string>();
            pathParts.Insert(0, ""); // Home page
            return pathParts;
        }

        private Page GetPageFromPathParts(RequestContext requestContext, List<string> pathParts)
        {
            // Get all sites
            var siteRepo = new SiteRepository(); // TODO: Use DI
            var sites = siteRepo.GetAllSitesWithDomains();

            // Attempt to get site from domain
            var site =
                sites.FirstOrDefault(
                    s =>
                        s.Domains.Any(
                            d =>
                                requestContext.HttpContext.Request.Url != null &&
                                string.Equals(d.Domain, requestContext.HttpContext.Request.Url.Host,
                                    StringComparison.InvariantCultureIgnoreCase)));

            // Fallback to first site
            if (site == null)
            {
                site = sites.FirstOrDefault();
            }

            // Bail if there are no sites setup yet
            if (site == null)
            {
                return null;
            }

            // Find page with url
            var pageRepo = new PageRepository(); // TODO: Use DI
            var sitePages = pageRepo.GetPagesBySite(site.Id);
            var currentPage = sitePages.GetHomepage();
            var pages = new List<Page> {currentPage};
            while (pages.Any() && pathParts.Any())
            {
                var matchingPage = pages.FirstOrDefault(p => string.Equals(p.Slug, pathParts.First()));
                if (matchingPage != null)
                {
                    currentPage = matchingPage;
                    pages = currentPage.Children;
                    pathParts.RemoveAt(0);

                    if (!pathParts.Any())
                    {
                        return currentPage;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        private void ExecuteControllerForPage(RequestContext requestContext, Page page)
        {
            var pageType = page.Type;
            var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            IController controller;
            try
            {
                controller = controllerFactory.CreateController(requestContext, pageType);
                requestContext.RouteData.Values.Add("controller", pageType);
            }
            catch (HttpException ex)
            {
                var defaultControllerName = "DefaultContent";
                controller = controllerFactory.CreateController(requestContext, defaultControllerName);
                requestContext.RouteData.Values.Add("controller", defaultControllerName);
            }
            requestContext.RouteData.Values.Add("action", "Index");
            controller.Execute(requestContext);
        }
    }
}