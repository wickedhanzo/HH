using System.Web;
using System.Web.Mvc;
using Ninject;

namespace HouseHoldApp.MVC.Infrastructure.Atrributes
{
    public class HouseHoldAttribute : ActionFilterAttribute
    {       
        [Inject]
        public ICurrentUser CurrentUser { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CurrentUser.HasHouseHold)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            else
                base.OnActionExecuting(filterContext);
        }
    }
}