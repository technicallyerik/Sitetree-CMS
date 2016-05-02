using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitetree.DataAccess.Models;
using Sitetree.DataAccess.Repositories;
using SiteTree.Web.Controllers;

namespace SiteTree.Web.Routing
{
    public class DefaultCmsHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var requestContext = request.RequestContext;

            var pathParts = GetPathPartsFromRequestContext(requestContext);
            var page = GetPageFromPathParts(requestContext, pathParts);
            if (page != null)
            {
                ExecuteControllerForPage(requestContext, page);
            }
            else
            {
                ReturnNotFoundResponse(context);
            }
        }

        public bool IsReusable => true;

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
            var siteRepo = new SiteRepository(); // TODO: Create service and use DI
            var sites = siteRepo.GetAllWithDomainsAndPages();

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
            var currentPage = site.Homepage;
            var pages = new List<Page> { currentPage };
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
                var defaultControllerName = "DefaultSitetree";
                controller = controllerFactory.CreateController(requestContext, defaultControllerName);
                requestContext.RouteData.Values.Add("controller", defaultControllerName);
            }
            requestContext.RouteData.Values.Add("action", "Index");
            controller.Execute(requestContext);
        }

        private void ReturnNotFoundResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 404;
            httpContext.Response.Write("Could not find page for path");
        }
    }
}