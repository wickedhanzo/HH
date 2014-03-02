using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.TestBase.ObjectMothers.ViewModels
{
    public static class LoginUserModelObjectMother
    {
        public static LoginUserModel GetLoginUserModel()
        {
            LoginUserModel loginUserModel = new LoginUserModel
            {
                UserName = "UserName1",
                Password = "Password1"
            };
            return loginUserModel;
        }
    }
}
