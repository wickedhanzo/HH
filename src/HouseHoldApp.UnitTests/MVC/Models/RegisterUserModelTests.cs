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
                UserName = "testaddress@gmail.com",
                Password = "test",
                ConfirmPassword = "test2"
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase("","")]
        [TestCase("", "password")]
        [TestCase("username", "")]
        public void RegisterHttpPost_ViewStateInvalid_CalledWithEmptyRequiredFields(string username, string password)
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                UserName = username,
                Password = password,
                ConfirmPassword = password
            };
            //Act
            bool validState = IsValidState(registerUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase("username", "pw")]
        [TestCase("username", "12345 ")]
        public void RegisterHttpPost_ViewStateInvalid_PasswordShorterThanSix(string username, string password)
        {
            //Arrange
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                UserName = username,
                Password = password,
                ConfirmPassword = password
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
                UserName = "test@gmail.com",
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
