using System.Collections;
using System.Collections.Generic;

namespace HouseHoldApp.Domain.Entities
{
    public class HouseHold : EntityBase
    {
        public string Name { get; set; }
        public ICollection<HouseHoldMember> HouseHoldMembers { get; set; }
    }
}
