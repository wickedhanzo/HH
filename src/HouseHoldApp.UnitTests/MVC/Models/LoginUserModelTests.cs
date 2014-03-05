using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HouseHoldApp.MVC.Models;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Models
{
    public class LoginUserModelTests
    {
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase("username","")]
        [TestCase("username", " ")]
        [TestCase("","password")]
        [TestCase(" ", "password")]
        public void LoginUserModel_ModelStateInvalid_CalledWithEmptyRequiredFields(string username, string password)
        {
            //Arrange
            LoginUserModel loginUserModel = new LoginUserModel {UserName = username, Password = password};
            //Act
            bool validState = IsValidState(loginUserModel);
            //Assert
            Assert.False(validState);
        }

        [TestCase]
        public void RegisterHttpPost_ViewStateValid_CalledWithNonEmptyRequired()
        {
            //Arrange
            LoginUserModel loginUserModel = new LoginUserModel
            {
                UserName = "username",
                Password = "password"
            };
            //Act
            bool validState = IsValidState(loginUserModel);
            //Assert
            Assert.True(validState);
        }

        private bool IsValidState(LoginUserModel registerUserModel)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(registerUserModel, null, null);
            return Validator.TryValidateObject(registerUserModel, context, validationResults, true);
        }
    }
}
