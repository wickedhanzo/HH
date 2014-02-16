using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Infrastructure.UnitOfWork;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Models;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private Mock<IPasswordHasher> _passwordHasher;
        private Mock<IUserService> _userService;
        private Mock<IUnitOfWork> _uow;
        private Mock<IAuthenticationService> _authenticationService;

        [TestCase]
        public void Register_Returns_ViewResult()
        {
            AccountController controller = CreateAccountController();
            var actual = controller.Register() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [TestCase]
        public void RegisterHttpPost_InvalidModelState_ReturnsView()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            controller.ModelState.AddModelError("Test", "Test");
            RegisterUserModel registerUserModel = new RegisterUserModel();
            //Act
            var actual = controller.Register(registerUserModel);
            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [TestCase]
        public void RegisterHttpPost_ValidModelState_RegistersUserWithRightParameters()
        {
            //Arrange
            AccountController controller = CreateAccountController();
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                EmailAddress = "test@gmail.com",
                Password = "testpw",
                ConfirmPassword = "testpw"
            };
            _passwordHasher.Setup(p => p.HashPassword("testpw")).Returns("testpwHashed");
            //Act
            controller.Register(registerUserModel);
            // Assert
            _userService.Verify(u => u.RegisterUser(It.Is<User>(n => n.EmailAddress.Equals(registerUserModel.EmailAddress) && n.Password.Equals("testpwHashed"))), Times.Once);          
        }

        [TestCase]
        public void RegisterHttpPost_ViewStateInvalid_CalledWithDifferentPasswords()
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                EmailAddress = "testaddress@gmail.com",
                Password = "test",
                ConfirmPassword = "test2"
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase]
        public void RegisterHttpPost_ViewStateInvalid_CalledWithEmptyEmailAddress()
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                EmailAddress = string.Empty,
                Password = "test",
                ConfirmPassword = "test"
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase]
        public void RegisterHttpPost_ViewStateInvalid_CalledWithEmptyPasswordAndEmptyConfirmPassword()
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                EmailAddress = "test@gmail.com",
                Password = string.Empty,
                ConfirmPassword = string.Empty,
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase]
        public void RegisterHttpPost_ViewStateValid_CalledWithValidInfo()
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                EmailAddress = "test@gmail.com",
                Password = "testpw",
                ConfirmPassword = "testpw",
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.True(validState);
        }

        private bool IsValidState(RegisterUserModel registerUserModel)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(registerUserModel, null, null);
            return Validator.TryValidateObject(registerUserModel, context, validationResults, true);
        }

        private AccountController CreateAccountController()
        {
            _passwordHasher = new Mock<IPasswordHasher>();
            _userService = new Mock<IUserService>();
            _uow = new Mock<IUnitOfWork>();
            _authenticationService = new Mock<IAuthenticationService>();
            AccountController controller = new AccountController(_passwordHasher.Object, _userService.Object, _authenticationService.Object, _uow.Object);
            return controller;
        }
    }
}