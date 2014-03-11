using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<RegisterUserModel, User>();
            CreateMap<HouseHoldCreateModel, HouseHold>();
            CreateMap<User, UserModel>();
            CreateMap<HouseHoldMember, HouseHoldMemberModel>()
                .ForMember(
                    h => h.UserModel,
                    m => m.MapFrom(
                        q => Mapper.Map<User, UserModel>(q.User))
                );
     
            CreateMap<HouseHold, HouseHoldModel>()
                .ForMember(h => h.HouseHoldMemberModels,
                    m => m.MapFrom
                        (
                            q =>
                                Mapper.Map<ICollection<HouseHoldMember>, ICollection<HouseHoldMemberModel>>(
                                    q.HouseHoldMembers)
                        ))
                        ;
        }
    }
}