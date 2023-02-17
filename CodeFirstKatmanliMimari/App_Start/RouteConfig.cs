using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeFirstKatmanliMimari
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "ArticleAdmin",
          url: "admin-makale/listele",
          defaults: new { controller = "ArticleAdmin", action = "Index", String = "" }
      );

            routes.MapRoute(
               name: "ArticleDetail",
               url: "{CategoryName}/{linkUrl}",
               defaults: new { controller = "Home", action = "Detail", String = "" }
           );

            routes.MapRoute(
              name: "Category",
              url: "{CategoryName}",
              defaults: new { controller = "Category", action = "Index", String = "" }
          );

            routes.MapRoute(
            name: "AuthorDetail",
            url: "yazarlar/{authorName}",
            defaults: new { controller = "Author", action = "Index", String = "" }
        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
