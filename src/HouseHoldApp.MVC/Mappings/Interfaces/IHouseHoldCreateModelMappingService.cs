﻿using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings.Interfaces
{
    public interface IHouseHoldCreateModelMappingService
    {
        HouseHold MapToEntity(HouseHoldCreateModel houseHoldCreateModel);
    }
}
