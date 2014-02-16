using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Infrastructure.UnitOfWork;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.RepositoryEF;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.RepositoryEF.UnitOfWork;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Account")
            {
                HhContext context = new HhContext();
                IPasswordHasher passwordHasher = new PasswordHasher();
                IUserRepository userRepository = new UserRepositoryEF(context.Set<User>());
                IUnitOfWork unitOfWork = new UnitOfWorkEF(context,userRepository);
                IUserService userService = new UserService(userRepository);
                IAuthenticationService authenticationService = new FormsAuthenticationService();
                return new AccountController(passwordHasher, userService, authenticationService, unitOfWork);
            }
            return new HomeController();
        }
    }
}