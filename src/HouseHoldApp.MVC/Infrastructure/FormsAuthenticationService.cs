using System.Web.Security;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void LogIn(string emailAddress)
        {
            FormsAuthentication.SetAuthCookie(emailAddress, false);
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}