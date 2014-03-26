using System.Collections.Generic;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{
    public class GenderModelMappingService : IGenderModelMappingService
    {
        public IEnumerable<GenderModel> MapToView(IEnumerable<Gender> genders)
        {
            return Mapper.Map<IEnumerable<Gender>, IEnumerable<GenderModel>>(genders);
        }
    }
}