using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.TestBase.ObjectMothers.ViewModels;
using Moq;
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
            Mock<IGenderModelMappingService> genderModelMappingService = new Mock<IGenderModelMappingService>();
            Mock<IGenderService> genderService = new Mock<IGenderService>();
            RegisterUserModelMappingService registerUserModelMappingService = new RegisterUserModelMappingService(genderModelMappingService.Object, genderService.Object);
            RegisterUserModel registerUserModel = RegisterUserModelObjectMother.GetValidRegisterUserModel();
            User user = registerUserModelMappingService.MapToEntity(registerUserModel);
           
            Assert.True(user.UserName == registerUserModel.UserName
                     && user.FirstName == registerUserModel.FirstName
                     && user.LastName == registerUserModel.LastName);
        }
    }
}
