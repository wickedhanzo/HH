using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Controllers;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.TestBase.ObjectMothers.ViewModels;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Controllers
{
    [TestFixture]
    public class HouseHoldControllerTests
    {
        private Mock<IHouseHoldService> _houseHoldService;
        private Mock<IHouseHoldMemberService> _houseHoldMemberService;
        private Mock<IUnitOfWork> _uow;
        private Mock<ICurrentUser> _currentUser;

        #region Index
        [TestCase]
        public void Index_ReturnsView()
        {
            HouseHoldController controller = CreateHouseHoldController();
            var actual = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }
        #endregion
        #region Create
        [TestCase]
        public void Create_ReturnsView()
        {
            //Arrange
            HouseHoldController controller = CreateHouseHoldController();
            //Act
            var actual = controller.Create() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [TestCase]
        public void CreatePost_ValidModelState_CallsAddOnHouseHoldService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = HouseHoldCreateModelObjectMother.GetHouseHoldCreateModel();
            HouseHoldController controller = CreateHouseHoldController();
            //Act
            controller.Create(houseHoldCreateModel);
            //Assert
            _houseHoldService.Verify(hs => hs.CreateHouseHold(It.Is<HouseHold>(h => h.Name.Equals(houseHoldCreateModel.Name))), Times.Once);
        }

        [TestCase]
        public void CreatePost_ValidModelState_CallsAddOnHouseHoldMemberService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = HouseHoldCreateModelObjectMother.GetHouseHoldCreateModel();
            HouseHoldController controller = CreateHouseHoldController();
            //Act
            controller.Create(houseHoldCreateModel);
            _houseHoldMemberService.Verify(
                hms =>
                    hms.CreateHouseHoldMember(
                        It.IsAny<HouseHoldMember>()), Times.Once);
        }

        [TestCase]
        public void CreatePost_ValidModelState_CallsSaveChangesOnUnitOfWork()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = HouseHoldCreateModelObjectMother.GetHouseHoldCreateModel();
            HouseHoldController controller = CreateHouseHoldController();
            //Act
            controller.Create(houseHoldCreateModel);
            _uow.Verify(u => u.SaveChanges(), Times.Once);
        }

        [TestCase]
        public void CreatePost_ValidModelState_RedirectsToHouseHoldIndex()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = HouseHoldCreateModelObjectMother.GetHouseHoldCreateModel();
            HouseHoldController controller = CreateHouseHoldController();
            //Act
            RedirectToRouteResult actual = (RedirectToRouteResult)controller.Create(houseHoldCreateModel);
            // Assert
            Assert.True(actual.RouteValues["action"].ToString() == "Index" &&
            actual.RouteValues["controller"].ToString() == "HouseHold");
        }

        [TestCase]
        public void CreatePost_InvalidModelState_DoesNotCallCreateOnHouseHoldService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel {Name = "HouseHold1"};
            HouseHoldController controller = CreateHouseHoldController();
            controller.ModelState.AddModelError("Test", "Test");
            //Act
            controller.Create(houseHoldCreateModel);
            //Assert
            _houseHoldService.Verify(hs => hs.CreateHouseHold(It.IsAny<HouseHold>()), Times.Never);
        }


        [TestCase]
        public void CreatePost_InvalidModelState_DoesNotCallCreateOnHouseHoldMemberService()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel { Name = "HouseHold1" };
            HouseHoldController controller = CreateHouseHoldController();
            controller.ModelState.AddModelError("Test", "Test");
            //Act
            controller.Create(houseHoldCreateModel);
            //Assert
            _houseHoldMemberService.Verify(hs => hs.CreateHouseHoldMember(It.IsAny<HouseHoldMember>()), Times.Never);
        }

        [TestCase]
        public void CreatePost_InvalidModelState_ReturnsViewResult()
        {
            //Arrange
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel { Name = "HouseHold1" };
            HouseHoldController controller = CreateHouseHoldController();
            controller.ModelState.AddModelError("Test", "Test");
            //Act
            var actual = controller.Create(houseHoldCreateModel) as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }
        #endregion Create

        public HouseHoldController CreateHouseHoldController()
        {        
            _houseHoldService = new Mock<IHouseHoldService>();
            _houseHoldMemberService = new Mock<IHouseHoldMemberService>();
            _uow = new Mock<IUnitOfWork>();
            _currentUser = new Mock<ICurrentUser>();
            _currentUser.Setup(c => c.UserName).Returns("user1@email.com");
            HouseHoldController controller = new HouseHoldController(_houseHoldService.Object, _houseHoldMemberService.Object , _uow.Object, _currentUser.Object);
            return controller;
        }
    }
}