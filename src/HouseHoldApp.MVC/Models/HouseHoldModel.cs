using System.Collections.Generic;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.MVC.Models
{
    public class HouseHoldModel
    {
        public string Name { get; set; }
        public List<HouseHoldMemberModel> HouseHoldMemberModels { get; set; }
    }
}