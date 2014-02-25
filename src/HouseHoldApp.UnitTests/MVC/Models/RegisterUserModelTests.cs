using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Models;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Models
{
    public class RegisterUserModelTests
    {
        [TestCase]
        public void RegisterUserModel_Invalid_CalledWithDifferentPasswords()
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
    }
}
