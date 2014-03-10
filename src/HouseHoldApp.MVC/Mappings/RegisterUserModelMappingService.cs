using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{
    public class RegisterUserModelMappingService : IRegisterUserModelMappingService
    {
        public User MapToEntity(RegisterUserModel registerUserModel)
        {
            return Mapper.Map<User>(registerUserModel);
        }
    }
}