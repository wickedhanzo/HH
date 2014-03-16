using System.Web;

namespace HouseHoldApp.MVC.Infrastructure
{
    public interface ISessionHelper
    {
        int? HouseHoldId { get; set; }
    }

    public class SessionHelper : ISessionHelper
    {
        public int? HouseHoldId 
        {
            get { return (int?)HttpContext.Current.Session["HouseHoldId"];}
            set { HttpContext.Current.Session["HouseHoldId"] = value; }
        }
    }
}