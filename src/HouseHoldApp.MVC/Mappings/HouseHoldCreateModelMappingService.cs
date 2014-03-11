using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{
    public class HouseHoldCreateModelMappingService : IHouseHoldCreateModelMappingService
    {
        public HouseHold MapToEntity(HouseHoldCreateModel houseHoldCreateModel)
        {
            return Mapper.Map<HouseHold>(houseHoldCreateModel);
        }
    }
}