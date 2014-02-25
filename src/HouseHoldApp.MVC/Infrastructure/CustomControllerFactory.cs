using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Models;
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
            HhContext context = new HhContext();
            IPasswordHasher passwordHasher = new PasswordHasher();
            IUserRepository userRepository = new UserRepositoryEF(context.Set<User>());
            IHouseHoldRepository houseHoldRepository = new HouseHoldRepositoryEF(context.Set<HouseHold>());
            IHouseHoldService houseHoldService = new HouseHoldService(houseHoldRepository);
            IHouseHoldMemberRepository houseHoldMemberRepository = new HouseHoldMemberRepositoryEF(context.Set<HouseHoldMember>());
            IHouseHoldMemberService houseHoldMemberService = new HouseHoldMemberService(houseHoldMemberRepository);
            IUnitOfWork unitOfWork = new UnitOfWorkEF(context, userRepository, houseHoldRepository, houseHoldMemberRepository);
            IUserService userService = new UserService(userRepository);
            IAuthenticationService authenticationService = new FormsAuthenticationService();
            CurrentUser currentUser = null;
            if (HttpContext.Current != null)
            {
                currentUser = new CurrentUser(HttpContext.Current.User.Identity);
            }
            switch (controllerName)
            {
                case "Account":
                    return new AccountController(passwordHasher, userService, authenticationService, unitOfWork);
                case "HouseHold":
                    return new HouseHoldController(houseHoldService, houseHoldMemberService, userService, unitOfWork, currentUser);
                default: return new HomeController();
            }

        }
    }
}