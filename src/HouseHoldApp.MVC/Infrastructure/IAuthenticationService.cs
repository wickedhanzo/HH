namespace HouseHoldApp.MVC.Infrastructure
{
    public interface IAuthenticationService
    {
        void LogIn(string emailAddress);
        void LogOut();
    }
}