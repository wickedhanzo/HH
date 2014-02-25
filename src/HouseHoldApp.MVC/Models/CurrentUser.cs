using System.Security.Principal;
using System.Web.Security;

namespace HouseHoldApp.MVC.Models
{
    public class CurrentUser
    {
        public CurrentUser()
        {
            
        }

        public CurrentUser(IIdentity identity)
        {
            IsAuthenticated = identity.IsAuthenticated;
            EmailAddress = identity.Name;

            var formsIdentity = identity as FormsIdentity;

            if (formsIdentity != null && formsIdentity.Ticket.UserData != string.Empty)
            {
                UserId = int.Parse(formsIdentity.Ticket.UserData);
            }
        }

        public virtual string EmailAddress { get; private set; }
        public virtual bool IsAuthenticated { get; private set; }
        public virtual int UserId { get; private set; }
    }
}