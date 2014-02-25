using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Models;
using HouseHoldApp.RepositoryEF.Repositories;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Controllers
{
    public class HouseHoldController : Controller
    {
        private readonly IHouseHoldService _houseHoldService;
        private readonly IHouseHoldMemberService _houseHoldMemberService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;
        private readonly CurrentUser _currentUser;

        public HouseHoldController(IHouseHoldService houseHoldService,
                                   IHouseHoldMemberService houseHoldMemberService,
                                   IUserService userService,
                                   IUnitOfWork uow,
                                   CurrentUser currentUser)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
            _userService = userService;
            _uow = uow;
            _currentUser = currentUser;
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HouseHoldCreateModel houseHoldCreateModel)
        {
            if (ModelState.IsValid)
            {
                HouseHold houseHold = new HouseHold {Name = houseHoldCreateModel.Name};
                _houseHoldService.CreateHouseHold(houseHold);
                User user = _userService.FindByEmailAddress(_currentUser.EmailAddress);
                HouseHoldMember houseHoldMember = new HouseHoldMember
                {
                    EmailAddress = user.EmailAddress,
                    HouseHold = houseHold,
                    Id = user.Id,
                    Password = user.Password
                };
                _houseHoldMemberService.CreateHouseHoldMember(houseHoldMember);
                _uow.SaveChanges();
                return RedirectToAction("Index", "HouseHold");
            }
            return View();
        }
	}
}