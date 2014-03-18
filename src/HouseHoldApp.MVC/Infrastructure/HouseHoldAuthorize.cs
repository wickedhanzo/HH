﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class HouseHoldAuthorizeAttribute : AuthorizeAttribute
    {
        
        [Inject]
        public ICurrentUser CurrentUser { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            return CurrentUser.HouseHoldId != null && CurrentUser.HouseHoldId != 0;
        }
    }
}