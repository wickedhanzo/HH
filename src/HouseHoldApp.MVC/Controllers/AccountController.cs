using System.Web.Mvc;
using System.Web.Security;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Infrastructure.UnitOfWork;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Models;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _uow;

        public AccountController(IPasswordHasher passwordHasher,
                                 IUserService userService, 
                                 IAuthenticationService authenticationService,
                                 IUnitOfWork uow)
        {
            _passwordHasher = passwordHasher;
            _userService = userService;
            _authenticationService = authenticationService;
            _uow = uow;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel registerUserModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    EmailAddress = registerUserModel.EmailAddress,
                    Password = _passwordHasher.HashPassword(registerUserModel.Password)
                };
                using (_uow)
                {
                    _userService.RegisterUser(user);
                    _uow.SaveChanges();
                    _authenticationService.Signin(registerUserModel.EmailAddress);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}