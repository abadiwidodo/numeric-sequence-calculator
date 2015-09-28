using System.Web.Mvc;
using System.Web.Routing;

namespace NumericSequenceCalculator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Calculate", id = UrlParameter.Optional }
            );
        }
    }
}
