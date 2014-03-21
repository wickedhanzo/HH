using System;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.TestBase.ObjectMothers
{
    public static class UserObjectMother
    {
        private static readonly Random Random = new Random();
        public static User GetUserWithRandomId()
        {
            User user = new User
            {
                Id = Random.Next(10000).ToString()          
            };
            user.UserName = "UserName" + user.Id;
            return user;
        }
    }
}
