using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseHoldApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
