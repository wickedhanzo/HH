using System;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class HouseHoldObjectMother
    {
        public static HouseHold GetHouseHoldWithRandomId()
        {
            HouseHold houseHold = new HouseHold { Id = new Random(10000).Next() };
            return houseHold;
        }
    }
}
