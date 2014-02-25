using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Controllers
{
    [TestFixture]
    public class HouseHoldControllerTests
    {
        private Mock<IHouseHoldService> _houseHoldService;
        private Mock<IHouseHoldMemberService> _houseHoldMemberService;
        private Mock<IUserService> _userService;
        private Mock<IUnitOfWork> _uow;
        private Mock<CurrentUser> _currentUser;

        [TestCase]
        public void Create_ReturnsView()
        {
            HouseHoldController controller = CreateHouseHoldController();
            var actual = controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [TestCase]
        public void Index_ReturnsView()
        {
            HouseHoldController controller = CreateHouseHoldController();
            var actual = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [TestCase]
        public void CreatePost_ValidModelState_CallsAddOnHouseHoldAndHouseHoldMemberService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel {Name = "HouseHold1"};
            HouseHoldController controller = CreateHouseHoldController();
            _userService.Setup(us => us.FindByEmailAddress("user1@email.com"))
                .Returns(UserObjectMother.GetUserWithRandomId());
            //Act
            controller.Create(houseHoldCreateModel);
            //Assert
            _houseHoldService.Verify(hs => hs.CreateHouseHold(It.Is<HouseHold>(h => h.Name.Equals(houseHoldCreateModel.Name))), Times.Once);
            _houseHoldMemberService.Verify(
                hms =>
                    hms.CreateHouseHoldMember(
                        It.Is<HouseHoldMember>(hm => hm.HouseHold.Name.Equals(houseHoldCreateModel.Name))),Times.Once);
        }

        [TestCase]
        public void CreatePost_InvalidModelState_DoesntCallCreateOnHouseHoldAndHouseHoldMemberService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel {Name = "HouseHold1"};
            HouseHoldController controller = CreateHouseHoldController();
            controller.ModelState.AddModelError("Test", "Test");
            //Act
            controller.Create(houseHoldCreateModel);
            //Assert
            _houseHoldService.Verify(hs => hs.CreateHouseHold(It.IsAny<HouseHold>()), Times.Never);
            _houseHoldMemberService.Verify(hs => hs.CreateHouseHoldMember(It.IsAny<HouseHoldMember>()), Times.Never);
        }

        public HouseHoldController CreateHouseHoldController()
        {        
            _houseHoldService = new Mock<IHouseHoldService>();
            _houseHoldMemberService = new Mock<IHouseHoldMemberService>();
            _userService = new Mock<IUserService>();
            _uow = new Mock<IUnitOfWork>();
            _currentUser = new Mock<CurrentUser>();
            _currentUser.Setup(c => c.EmailAddress).Returns("user1@email.com");
            HouseHoldController controller = new HouseHoldController(_houseHoldService.Object, _houseHoldMemberService.Object , _userService.Object, _uow.Object, _currentUser.Object);
            return controller;
        }
    }
}