using System.Collections.Generic;

namespace HouseHoldApp.MVC.Models
{
    public class HouseHoldModel
    {
        public string Name { get; set; }
        public List<HouseHoldMemberModel> HouseHoldMemberModels { get; set; }
    }
}