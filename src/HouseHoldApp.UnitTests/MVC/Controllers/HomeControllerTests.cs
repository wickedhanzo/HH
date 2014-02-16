using System.Web.Mvc;
using HouseHoldApp.MVC.Controllers;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [TestCase]
        public void Index_ReturnsView()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            var actual = controller.Index();
            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }
    }
}
