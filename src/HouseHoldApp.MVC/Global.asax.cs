using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using HouseHoldApp.RepositoryEF;
using HouseHoldApp.RepositoryEF.Migrations; 

namespace HouseHoldApp.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HhContext, Configuration>()); 
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
