using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookProject.WebMVC
{
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication   //System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
