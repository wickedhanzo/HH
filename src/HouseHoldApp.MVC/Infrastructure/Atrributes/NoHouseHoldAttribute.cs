using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseHoldApp.MVC.Controllers;
using Ninject;

namespace HouseHoldApp.MVC.Infrastructure.Atrributes
{
    public class NoHouseHoldAttribute : ActionFilterAttribute
    {

        [Inject]
        public ICurrentUser CurrentUser { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Check your condition here
            if (CurrentUser.HasHouseHold)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            else
                base.OnActionExecuting(filterContext);
        }

    }
}