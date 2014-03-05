using System.Threading.Tasks;
using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HouseHoldApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly IAuthenticationManager _authenticationManager;

        public AccountController(IUserService userService,
                                 IAuthenticationManager authenticationManager)
        {          
            _userService = userService;
            _authenticationManager = authenticationManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserModel registerUserModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerUserModel.UserName
                };
                IdentityResult result = await _userService.CreateAsync(user, registerUserModel.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUserModel loginUserModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindAsync(loginUserModel.UserName, loginUserModel.Password);
                if (user != null)
                {
                    await SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(loginUserModel);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private async Task SignInAsync(User user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}