using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homsey
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        "Article Router",
        "Article/{article}",
        new { controller = "Article", action = "Index" }
      );

      routes.MapRoute(
          name: "Home Page",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}