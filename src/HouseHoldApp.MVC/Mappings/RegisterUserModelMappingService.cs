using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{


    public class RegisterUserModelMappingService : IRegisterUserModelMappingService
    {
        private readonly IGenderModelMappingService _genderModelMappingService;
        private readonly IGenderService _genderService;

        public RegisterUserModelMappingService(IGenderModelMappingService genderModelMappingService, IGenderService genderService)
        {
            _genderModelMappingService = genderModelMappingService;
            _genderService = genderService;
        }

        public User MapToEntity(RegisterUserModel registerUserModel)
        {
            return Mapper.Map<User>(registerUserModel);
        }

        public RegisterUserModel MapToView(User user)
        {
            RegisterUserModel registerUserModel = Mapper.Map<RegisterUserModel>(user) ?? new RegisterUserModel();
            IEnumerable<Gender> genders = _genderService.GetAll();
            IEnumerable<GenderModel> genderModels = _genderModelMappingService.MapToView(genders);
            registerUserModel.GenderModels = genderModels;
            return registerUserModel;
        }
    }
}