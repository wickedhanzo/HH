using System;
using System.Collections.Generic;
using System.ComponentModel;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class HouseHoldObjectMother
    {
        private static readonly Random Random = new Random();
        public static HouseHold GetHouseHoldWithRandomId()
        {
            HouseHold houseHold = new HouseHold
            {
                Id = Random.Next(10000),
            };
            houseHold.Name = "HouseHold" + houseHold.Id;
            return houseHold;
        }

        public static HouseHold GetHouseHoldWith5HouseHoldMembers()
        {
            HouseHold houseHold = GetHouseHoldWithRandomId();

            List<HouseHoldMember> members = HouseHoldMemberObjectMother.CreateList(5);
            houseHold.HouseHoldMembers = members;
            return houseHold;
        }

        public static List<HouseHold> CreateList(int count)
        {
            List<HouseHold> houseHolds = new List<HouseHold>();

            for (int i = 0; i < count; i++)
            {
                houseHolds.Add(GetHouseHoldWith5HouseHoldMembers());
            }
            return houseHolds;
        }
    }
}
