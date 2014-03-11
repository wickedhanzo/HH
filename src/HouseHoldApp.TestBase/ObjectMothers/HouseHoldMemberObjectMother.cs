using System;
using System.Collections.Generic;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class HouseHoldMemberObjectMother
    {
        private static readonly Random Random = new Random();
        public static HouseHoldMember GetHouseHoldMemberWithRandomId()
        {
            HouseHoldMember houseHoldMember = new HouseHoldMember
            {
                Id = Random.Next(10000),
                User = UserObjectMother.GetUserWithRandomId()
            };
            return houseHoldMember;
        }

        public static List<HouseHoldMember> CreateList(int count)
        {
            List<HouseHoldMember> houseHoldMembers = new List<HouseHoldMember>();
            
            for (int i = 0; i < count; i++)
            {
                HouseHoldMember houseHoldMember = GetHouseHoldMemberWithRandomId();
                houseHoldMembers.Add(houseHoldMember);
            }
            return houseHoldMembers;
        }
    }
}
