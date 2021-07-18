﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TEAM13SEP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             );*/

            routes.MapRoute(
           "Default", // Route name
           "{controller}/{action}/{id}", // URL with parameters
           new { area = "User", controller = "GopY", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
           new[] { "TEAM13SEP.Areas.User.Controllers" }
       ).DataTokens.Add("area", "User");

            routes.MapRoute(
          "Admin", // Route name
          "{controller}/{action}/{id}", // URL with parameters
          new { area = "Admin", controller = "GopY", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
          new[] { "TEAM13SEP.Areas.Admin.Controllers" }
      ).DataTokens.Add("area", "Admin");
        }
    }
}
