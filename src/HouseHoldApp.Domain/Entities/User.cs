using System.IO;
using HouseHoldApp.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseHoldApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
