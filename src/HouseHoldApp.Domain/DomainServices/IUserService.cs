using System.Security.Claims;
using System.Threading.Tasks;
using HouseHoldApp.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<User> FindAsync(string userName, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string applicationCookie);
    }
}
