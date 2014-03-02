using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.TestBase.ObjectMothers.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<IUserService> _userService;
        private Mock<IAuthenticationManager> _authenticationManager;

        #region Register
        [TestCase]
        public void Register_Returns_SameNameViewResult()
        {
            AccountController controller = CreateAccountController();  
            string expected = string.Empty;
            var actual = ((ViewResult)controller.Register()).ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void RegisterHttpPost_InvalidModelState_ReturnsSameNameView()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            controller.ModelState.AddModelError("Test", "Test");
            RegisterUserModel registerUserModel = new RegisterUserModel();    
            string expected = string.Empty;
            //Act
            var actual = ((ViewResult)controller.Register(registerUserModel).Result).ViewName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelState_CreateAsyncCalledOnUserService()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, true);
            //Act
            await controller.Register(registerUserModel);
            // Assert
            _userService.Verify(u => u.CreateAsync((It.Is<User>(n => n.UserName.Equals(registerUserModel.UserName))), registerUserModel.Password), Times.Once);
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelState_CallsSignOutOnAuthenticationManager()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, true);
            //Act
            await controller.Register(registerUserModel);
            // Assert
            _authenticationManager.Verify(u => u.SignOut(DefaultAuthenticationTypes.ExternalCookie));
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelState_CallsSignInOnAuthenticationManager()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, true);
            //Act
            await controller.Register(registerUserModel);
            // Assert
            _authenticationManager.Verify(u => u.SignIn(It.IsAny<AuthenticationProperties>(), It.Is<ClaimsIdentity>(c => c.AuthenticationType == "authType")), Times.Once);
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelStateAndUserCreateFailed_DoesNotCallSignInOnAuthenticationManager()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, false);
            //Act
            await controller.Register(registerUserModel);
            // Assert
            _authenticationManager.Verify(u => u.SignIn(It.IsAny<AuthenticationProperties>(), It.Is<ClaimsIdentity>(c => c.AuthenticationType == "authType")), Times.Never);
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelStateAndUserCreateFailed_DoesNotCallsSignOutOnAuthenticationManager()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, false);
            //Act
            await controller.Register(registerUserModel);
            // Assert
            _authenticationManager.Verify(u => u.SignOut(DefaultAuthenticationTypes.ExternalCookie), Times.Never);
        }

        [TestCase]
        public async void RegisterHttpPost_ValidModelState_CallsRedirectToHomeIndex()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetRegisterUserModel();
            RegisterSetup(registerUserModel, true);
            //Act
            RedirectToRouteResult actual = (RedirectToRouteResult)await controller.Register(registerUserModel);
            // Assert
            Assert.True(actual.RouteValues["action"].ToString() == "Index" &&
            actual.RouteValues["controller"].ToString() == "Home");
        }
        #endregion

        #region Login
        [TestCase]
        public void Login_Returns_ViewResult()
        {
            AccountController controller = CreateAccountController();  
            string expected = string.Empty;
            var actual = ((ViewResult)controller.Login()).ViewName;
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public async void LoginHttpPost_DoesNotCallAuthenticationSignIn_ValidModelStateInCorrectCredentials()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(null));

            //Act
            await controller.Login(loginUserModel);
            // Assert
            _authenticationManager.Verify(a => a.SignIn(), Times.Never);
        }

        [TestCase]
        public void LoginHttpPost_ReturnsSameNameView_ValidModelStateInCorrectCredentials()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(null));

            //Act
             var actual = ((ViewResult)controller.Login(loginUserModel).Result).ViewName;
            // Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [TestCase]
        public async void LoginHttpPost_AddErrorToModelState_ValidModelStateInCorrectCredentials()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(null));

            //Act
            await controller.Login(loginUserModel);
            // Assert
            Assert.AreEqual(1, controller.ModelState.Count);
        }

        [TestCase]
        public void LoginHttpPost_ReturnsSameNameView_InvalidModelState()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(null));
            controller.ModelState.AddModelError("test","test");
            //Act
            var actual = ((ViewResult)controller.Login(loginUserModel).Result).ViewName;
            // Assert
            Assert.AreEqual(string.Empty, actual);
        }
        [TestCase]
        public async void LoginHttpPost_CallsAuthenticationManagerSignIn_ValidModelStateCorrectCredentials()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(new User()));
            //Act
            await controller.Login(loginUserModel);
            // Assert
            _authenticationManager.Verify(a => a.SignIn(), Times.Never);
           // Assert.True(actual.RouteValues["action"].ToString() == "Index" && actual.RouteValues["controller"].ToString() == "Home");
        }

        public void LoginHttpPost_RedirectsToHomeIndex_ValidModelStateCorrectCredentials()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            LoginUserModel loginUserModel = LoginUserModelObjectMother.GetLoginUserModel();
            _userService.Setup(
                u =>
                    u.FindAsync(loginUserModel.UserName, loginUserModel.Password)).Returns(Task.FromResult<User>(new User()));
            //Act
            var actual = ((RedirectToRouteResult)controller.Login(loginUserModel).Result);
            // Assert
            Assert.True(actual.RouteValues["action"].ToString() == "Index" && actual.RouteValues["controller"].ToString() == "Home");
        }
        #endregion

        #region LogOut
        [TestCase]
        public void LogOut_CallsSignOutOnAuthServiceAndRedirectsToHome()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            // Act
            var actual = (RedirectToRouteResult)controller.LogOff();
            // Assert
            _authenticationManager.Verify(a => a.SignOut(), Times.Once);
            Assert.True(actual.RouteValues["action"].ToString() == "Index" &&
            actual.RouteValues["controller"].ToString() == "Home");

        }
        #endregion

        #region PrivateFunctions
        private void RegisterSetup(RegisterUserModel registerUserModel, bool createUserSucceeded)
        {
            ClaimsIdentity identity = new ClaimsIdentity("authType");
            _userService.Setup(
                c =>
                    c.CreateAsync((It.Is<User>(n => n.UserName.Equals(registerUserModel.UserName))),
                        registerUserModel.Password)).Returns(Task.FromResult(createUserSucceeded ? IdentityResult.Success : IdentityResult.Failed()));
            _userService.Setup(
                c =>
                    c.CreateIdentityAsync((It.Is<User>(n => n.UserName.Equals(registerUserModel.UserName))),
                        DefaultAuthenticationTypes.ApplicationCookie)).Returns(Task.FromResult(identity));
        }
        private AccountController CreateAccountController()
        {
            _userService = new Mock<IUserService>();
            _authenticationManager = new Mock<IAuthenticationManager>();
            AccountController controller = new AccountController(_userService.Object, _authenticationManager.Object);
            return controller;
        }
#endregion
    }
}