using System.Web.Mvc;
using AutoMapper;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Mappings;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Controllers
{
    public class HouseHoldController : Controller
    {
        private readonly IHouseHoldService _houseHoldService;
        private readonly IHouseHoldMemberService _houseHoldMemberService;
        private readonly IUnitOfWork _uow;
        private readonly ICurrentUser _currentUser;
        private readonly IHouseHoldCreateModelMappingService _houseHoldCreateModelMappingService;

        public HouseHoldController(IHouseHoldService houseHoldService,
                                   IHouseHoldMemberService houseHoldMemberService,
                                   IUnitOfWork uow,
                                   ICurrentUser currentUser,
                                   IHouseHoldCreateModelMappingService houseHoldCreateModelMappingService)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
            _uow = uow;
            _currentUser = currentUser;
            _houseHoldCreateModelMappingService = houseHoldCreateModelMappingService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HouseHoldCreateModel houseHoldCreateModel)
        {
            if (ModelState.IsValid)
            {
                HouseHold houseHold = _houseHoldCreateModelMappingService.MapToEntity(houseHoldCreateModel);
                _houseHoldService.CreateHouseHold(houseHold);
                HouseHoldMember houseHoldMember = new HouseHoldMember
                {
                    UserId = _currentUser.UserId,
                    HouseHoldId = houseHold.Id
                };
                _houseHoldMemberService.CreateHouseHoldMember(houseHoldMember);
                _uow.SaveChanges();

                return RedirectToAction("Index", "HouseHold");
            }
            return View();
        }
    }
}