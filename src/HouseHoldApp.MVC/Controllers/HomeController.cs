using System.Web.Mvc;
using HouseHoldApp.MVC.Infrastructure;

namespace HouseHoldApp.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICurrentUser currentUser) : base(currentUser)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
	}
}