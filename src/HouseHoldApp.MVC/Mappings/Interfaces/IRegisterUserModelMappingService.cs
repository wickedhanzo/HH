using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings.Interfaces
{
    public interface IRegisterUserModelMappingService
    {
        User MapToEntity(RegisterUserModel registerUserModel);
    }
}