using System.Web.Mvc;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Infrastructure;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Infrastructure
{
    [TestFixture]
    public class CustomerControllerFactoryTests
    {
        [TestCase]
        public void CreateController_ReturnsAccountController_WhenCalledWithAccount()
        {
            CustomControllerFactory factory = new CustomControllerFactory();
            IController controller = factory.CreateController(null, "Account");
            Assert.IsInstanceOf<AccountController>(controller);
        }

        [TestCase]
        public void CreateController_ReturnsHomeController_WhenCalledWithHome()
        {
            CustomControllerFactory factory = new CustomControllerFactory();
            IController controller = factory.CreateController(null, "Home");
            Assert.IsInstanceOf<HomeController>(controller);
        }

        [TestCase]
        public void CreateController_ReturnsHouseHoldController_WhenCalledWithHouseHold()
        {
            CustomControllerFactory factory = new CustomControllerFactory();
            IController controller = factory.CreateController(null, "HouseHold");
            Assert.IsInstanceOf<HouseHoldController>(controller);
        }
    }
}
