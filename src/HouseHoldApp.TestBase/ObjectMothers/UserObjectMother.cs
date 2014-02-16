using System;
using HouseHoldApp.Domain;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class UserObjectMother
    {
        public static User GetUserWithRandomId()
        {
            User user = new User {Id = new Random(10000).Next()};
            return user;
        }
    }
}
