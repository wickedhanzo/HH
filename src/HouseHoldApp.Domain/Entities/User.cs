using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseHoldApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public string EmailAddress { get; set; }
    }
}
