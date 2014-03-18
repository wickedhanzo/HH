using System.Web;

namespace HouseHoldApp.MVC.Infrastructure
{
    public interface ISessionStorage
    {
        int? HouseHoldId { get; set; }
        void Clear();
    }

    public class HttpSessionStorage : ISessionStorage
    {
        public int? HouseHoldId 
        {
            get { return (int?)HttpContext.Current.Session["HouseHoldId"];}
            set { HttpContext.Current.Session["HouseHoldId"] = value; }
        }

        public void Clear()
        {
            HttpContext.Current.Session.Abandon();;
        }
    }
}