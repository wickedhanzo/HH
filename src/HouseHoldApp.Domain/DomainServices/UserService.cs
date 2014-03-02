using System.Security.Claims;
using System.Threading.Tasks;
using HouseHoldApp.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.Domain.DomainServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<User> FindAsync(string userName, string password)
        {
            return _userManager.FindAsync(userName, password);
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(User user, string applicationCookie)
        {
            return _userManager.CreateIdentityAsync(user, applicationCookie);
        }
    }
}
