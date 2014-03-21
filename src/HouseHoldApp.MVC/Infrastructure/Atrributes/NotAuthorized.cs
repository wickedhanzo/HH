﻿using System.Web;
using System.Web.Mvc;
using Ninject;

namespace HouseHoldApp.MVC.Infrastructure.Atrributes
{
    public class NotAuthorizedAttribute : ActionFilterAttribute
    {
        [Inject]
        public ICurrentUser CurrentUser { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Check your condition here
            if (CurrentUser.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            else
                base.OnActionExecuting(filterContext);
        }
    }
}