using System.Collections.Generic;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings.Interfaces
{
    public interface IGenderModelMappingService
    {
        IEnumerable<GenderModel> MapToView(IEnumerable<Gender> genders);
    }
}