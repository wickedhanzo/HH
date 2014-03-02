using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Infrastructure
{
    public interface ICurrentUser
    {
        string UserName { get; }
        bool IsAuthenticated { get; }
        string UserId { get; }
    }

    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IIdentity identity)
        {
            IsAuthenticated = identity.IsAuthenticated;
            UserName = identity.GetUserName();
            UserId = identity.GetUserId();
        }

        public virtual string UserName { get; private set; }
        public virtual bool IsAuthenticated { get; private set; }
        public virtual string UserId { get; private set; }
    }
}