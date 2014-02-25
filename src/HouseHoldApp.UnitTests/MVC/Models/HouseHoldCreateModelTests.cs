using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HouseHoldApp.MVC.Models;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Models
{
    [TestFixture]
    public class HouseHoldCreateModelTests
    {
        [TestCase]
        public void HouseHoldCreateModel_IsValid_NameFilledIn()
        {
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel {Name = "Name"};
            bool isValid = IsValidState(houseHoldCreateModel);
            Assert.True(isValid);
        }

        [TestCase]
        public void HouseHoldCreateModel_IsInvalid_NameNotFilledIn()
        {
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel { Name = "  " };
            bool isValid = IsValidState(houseHoldCreateModel);
            Assert.False(isValid);
        }

        private bool IsValidState(HouseHoldCreateModel houseHoldCreateModel)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(houseHoldCreateModel, null, null);
            return Validator.TryValidateObject(houseHoldCreateModel, context, validationResults, true);
        }
    }
}
