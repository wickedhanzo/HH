using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<User, RegisterUserModel>();
            CreateMap<RegisterUserModel, User>();
            CreateMap<HouseHoldCreateModel, HouseHold>();
            CreateMap<HouseHold, HouseHoldCreateModel>();
        }
    }
}