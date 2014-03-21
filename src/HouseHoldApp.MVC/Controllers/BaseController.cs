using System.Web.Mvc;
using HouseHoldApp.MVC.Infrastructure;

namespace HouseHoldApp.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ICurrentUser _currentUser;

        protected BaseController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                ViewBag.CurrentUser = _currentUser;
            }
        }
    }
}