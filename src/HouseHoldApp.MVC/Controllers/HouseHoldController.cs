using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.MVC.Infrastructure.Atrributes;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Controllers
{
    public class HouseHoldController : BaseController
    {
        private readonly IHouseHoldService _houseHoldService;
        private readonly IHouseHoldMemberService _houseHoldMemberService;
        private readonly IUnitOfWork _uow;
        private readonly ICurrentUser _currentUser;
        private readonly IHouseHoldCreateModelMappingService _houseHoldCreateModelMappingService;
        private readonly IHouseHoldModelMappingService _houseHoldModelMappingService;

        public HouseHoldController(IHouseHoldService houseHoldService,
                                   IHouseHoldMemberService houseHoldMemberService,
                                   IUnitOfWork uow,
                                   ICurrentUser currentUser,
                                   IHouseHoldCreateModelMappingService houseHoldCreateModelMappingService,
                                   IHouseHoldModelMappingService houseHoldModelMappingService) : base(currentUser)
        {
            _houseHoldService = houseHoldService;
            _houseHoldMemberService = houseHoldMemberService;
            _uow = uow;
            _currentUser = currentUser;
            _houseHoldCreateModelMappingService = houseHoldCreateModelMappingService;
            _houseHoldModelMappingService = houseHoldModelMappingService;
        }

        [Authorize]
        [HouseHold]
        public ActionResult Index()
        {
            HouseHold houseHold =_houseHoldService.GetById(_currentUser.HouseHoldId.Value);
            HouseHoldModel houseHoldModel = _houseHoldModelMappingService.MapToView(houseHold);
            return View(houseHoldModel);
        }

        [Authorize]
        [NoHouseHold]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [NoHouseHold]
        public ActionResult Search()
        {
            IEnumerable<HouseHold> houseHolds = _houseHoldService.GetAll();
            IEnumerable<HouseHoldModel> houseHoldModels = _houseHoldModelMappingService.MapToView(houseHolds);
            return View(houseHoldModels);
        }

        [HttpPost]
        public ActionResult Join(int id)
        {
            HouseHoldMember houseHoldMember = new HouseHoldMember
            {
                UserId = User.Identity.GetUserId(),
                HouseHoldId = id
            };
            _houseHoldMemberService.CreateHouseHoldMember(houseHoldMember);
            _uow.SaveChanges();
            return RedirectToAction("Index", "HouseHold");
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