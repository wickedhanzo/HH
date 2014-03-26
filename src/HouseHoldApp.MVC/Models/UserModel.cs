using System.Collections;
using System.Collections.Generic;
using AutoMapper.Internal;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.MVC.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImagePath { get; set; }
    }
}