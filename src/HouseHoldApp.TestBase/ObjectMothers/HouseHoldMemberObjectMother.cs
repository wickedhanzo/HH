using System;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class HouseHoldMemberObjectMother
    {
        public static HouseHoldMember GetHouseHoldMemberWithRandomId()
        {
            HouseHoldMember houseHoldMember = new HouseHoldMember { Id = new Random(10000).Next() };
            return houseHoldMember;
        }
    }
}
