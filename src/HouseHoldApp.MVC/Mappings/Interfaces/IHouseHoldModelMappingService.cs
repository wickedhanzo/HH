using System.Collections.Generic;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings.Interfaces
{
    public interface IHouseHoldModelMappingService
    {
        HouseHoldModel MapToView(HouseHold houseHold);
        IEnumerable<HouseHoldModel> MapToView(IEnumerable<HouseHold> houseHolds);
    }
}