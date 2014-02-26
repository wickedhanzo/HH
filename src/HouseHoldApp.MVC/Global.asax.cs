using System.Web.Mvc;
using System.Web.Routing;
using HouseHoldApp.MVC.Infrastructure;

namespace HouseHoldApp.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
