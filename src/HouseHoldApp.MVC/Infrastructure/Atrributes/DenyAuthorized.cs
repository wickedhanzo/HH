using System.Web;
using System.Web.Mvc;

namespace HouseHoldApp.MVC.Infrastructure.Atrributes
{
    public class DenyAuthorizedAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return !base.AuthorizeCore(httpContext);
        }
    }
}