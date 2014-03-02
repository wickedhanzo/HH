using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.TestBase.ObjectMothers.ViewModels
{
    public static class HouseHoldCreateModelObjectMother
    {
        public static HouseHoldCreateModel GetHouseHoldCreateModel()
        {
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel { Name = "HouseHold1" };
            return houseHoldCreateModel;
        }
    }
}
