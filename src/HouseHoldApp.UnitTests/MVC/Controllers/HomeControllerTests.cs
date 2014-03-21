using System.Web.Mvc;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Infrastructure;
using Moq;
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
            Mock<ICurrentUser> currentUser = new Mock<ICurrentUser>();
            HomeController controller = new HomeController(currentUser.Object);
            //Act
            var actual = controller.Index();
            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }
    }
}
