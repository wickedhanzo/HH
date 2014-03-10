using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Models;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Mappings
{
    [TestFixture]
    public class HouseHoldCreateModelMappingServiceTests
    {
        [TestCase]
        public void MapToEntity_ReturnsHouseHold_WithCorrectHouseHoldCreateModel()
        {
            Mapper.AddProfile(new AutoMapperProfile());
            HouseHoldCreateModelMappingService houseHoldCreateModelMappingService = new HouseHoldCreateModelMappingService();
            HouseHoldCreateModel houseHoldCreateModel = new HouseHoldCreateModel {Name = "HouseHold"};
            HouseHold houseHold = houseHoldCreateModelMappingService.MapToEntity(houseHoldCreateModel);
            Assert.True(houseHold.Name == houseHoldCreateModel.Name);
        }
    }
}
