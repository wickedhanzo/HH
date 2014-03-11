using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{
    public class HouseHoldModelMappingService : IHouseHoldModelMappingService
    {

        public HouseHoldModel MapToView(HouseHold houseHold)
        {
           return Mapper.Map<HouseHoldModel>(houseHold);
        }
    }
}