using System.Linq;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.TestBase.ObjectMothers;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Mappings
{
    [TestFixture]
    public class HouseHoldModelMappingServiceTests
    {
        [TestCase]
        public void MapToView_ReturnsCorrectView_WithHouseHold()
        {
            Mapper.AddProfile(new AutoMapperProfile());
            //Arrange
            HouseHoldModelMappingService houseHoldIndexModelMappingService = new HouseHoldModelMappingService();
            HouseHold houseHold = HouseHoldObjectMother.GetHouseHoldWith5HouseHoldMembers();
            //Act
            HouseHoldModel houseHoldModel = houseHoldIndexModelMappingService.MapToView(houseHold);
            //Assert
            Assert.True(houseHoldModel.Name == houseHold.Name
                && houseHoldModel.HouseHoldMemberModels.Count == 5 );
        }

    }
}
