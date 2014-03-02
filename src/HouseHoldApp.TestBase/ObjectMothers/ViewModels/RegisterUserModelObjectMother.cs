using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.TestBase.ObjectMothers.ViewModels
{
    public class RegisterUserModelObjectMother
    {
        public static RegisterUserModel GetRegisterUserModel()
        {
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                UserName = "UserName1",
                Password = "Password1",
                ConfirmPassword = "ConfirmPassword1"
            };
            return registerUserModel;
        }
    }
}
