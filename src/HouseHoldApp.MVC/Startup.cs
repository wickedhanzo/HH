using HouseHoldApp.Domain.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseHoldApp.MVC.Startup))]
namespace HouseHoldApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}