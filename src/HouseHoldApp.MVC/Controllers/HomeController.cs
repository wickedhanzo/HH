using System.Web.Mvc;

namespace HouseHoldApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}