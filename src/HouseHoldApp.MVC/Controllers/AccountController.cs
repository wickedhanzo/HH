using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Infrastructure;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Infrastructure.Atrributes;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HouseHoldApp.MVC.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IRegisterUserModelMappingService _registerUserModelMappingService;
        private readonly ICurrentUser _currentUser;
        private readonly ISessionStorage _sessionStorage;

        public AccountController(IUserService userService,
                                 IAuthenticationManager authenticationManager,
                                 IRegisterUserModelMappingService registerUserModelMappingService,
                                 ICurrentUser currentUser,
                                 ISessionStorage sessionStorage)
            : base(currentUser)
        {
            _userService = userService;
            _authenticationManager = authenticationManager;
            _registerUserModelMappingService = registerUserModelMappingService;
            _currentUser = currentUser;
            _sessionStorage = sessionStorage;
        }

        [NotAuthorized]
        public ActionResult Register()
        {
            RegisterUserModel registerUserModel = _registerUserModelMappingService.MapToView(new User());
            return View(registerUserModel);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserModel registerUserModel, HttpPostedFileBase userImage)
        {
            if (ModelState.IsValid)
            {
                User user = _registerUserModelMappingService.MapToEntity(registerUserModel);
                IdentityResult result = await _userService.CreateAsync(user, registerUserModel.Password);
                if (result.Succeeded)
                {
                    if (userImage != null)
                    {
                        string physicalPath = Server.MapPath(Constants.UserImageFolder + user.Id + ".jpg");
                        userImage.SaveAs(physicalPath);
                    }
                    await SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [NotAuthorized]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut();
            _sessionStorage.Clear();
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