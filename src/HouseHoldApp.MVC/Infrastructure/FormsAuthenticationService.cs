using System.Web.Security;

namespace HouseHoldApp.MVC.Infrastructure
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void Signin(string emailAddress)
        {
            FormsAuthentication.SetAuthCookie(emailAddress, false);
        }
    }
}