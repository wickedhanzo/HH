using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.TestBase.ObjectMothers.ViewModels
{
    public class RegisterUserModelObjectMother
    {
        public static RegisterUserModel GetValidRegisterUserModel()
        {
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                UserName = "UserName1",
                Password = "Password1",
                ConfirmPassword = "Password1",
                FirstName = "FirstName1",
                LastName = "LastName1"
            };
            return registerUserModel;
        }
    }
}
