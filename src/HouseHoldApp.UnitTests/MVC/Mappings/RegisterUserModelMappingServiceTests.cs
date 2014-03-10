using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Models;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Mappings
{
    [TestFixture]
    public class RegisterUserModelMappingServiceTests
    {
        [TestCase]
        public void MapToEntity_ReturnsCorrectUser_WithGivenRegisterUserModel()
        {
            Mapper.AddProfile(new AutoMapperProfile());
            RegisterUserModelMappingService registerUserModelMappingService = new RegisterUserModelMappingService();
            RegisterUserModel registerUserModel = new RegisterUserModel
            {
                UserName = "UserName",
                Password = "Password",
                ConfirmPassword = "ConfirmPassword"
            };
            User user = registerUserModelMappingService.MapToEntity(registerUserModel);
           
            Assert.True(user.UserName == registerUserModel.UserName);
        }
    }
}
