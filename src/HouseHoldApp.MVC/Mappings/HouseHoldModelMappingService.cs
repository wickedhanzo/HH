using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Infrastructure;
using HouseHoldApp.MVC.Mappings.Interfaces;
using HouseHoldApp.MVC.Models;

namespace HouseHoldApp.MVC.Mappings
{
    public class HouseHoldModelMappingService : IHouseHoldModelMappingService
    {
        public HouseHoldModel MapToView(HouseHold houseHold)
        {
            HouseHoldModel houseHoldModel = Mapper.Map<HouseHoldModel>(houseHold);
            ApplyUserImage(houseHoldModel);
            return houseHoldModel;
        }

        public IEnumerable<HouseHoldModel> MapToView(IEnumerable<HouseHold> houseHolds)
        {
            IEnumerable<HouseHoldModel> houseHoldModels = Mapper.Map<IEnumerable<HouseHoldModel>>(houseHolds);
            ApplyUserImage(houseHoldModels);
            return houseHoldModels;
        }

        private void ApplyUserImage(IEnumerable<HouseHoldModel> houseHoldModels)
        {
            foreach (HouseHoldModel houseHoldModel in houseHoldModels)
            {
                ApplyUserImage(houseHoldModel);
            }
        }

        private void ApplyUserImage(HouseHoldModel houseHoldModel)
        {
            foreach (var h in houseHoldModel.HouseHoldMemberModels)
            {
                string userImageRelativePath = Constants.UserImageFolder + h.UserModel.Id + ".jpg";
                string userImageFullPath = HttpContext.Current.Server.MapPath(userImageRelativePath);
                string userImagePath = File.Exists(userImageFullPath) ? userImageRelativePath : Constants.UnknownMaleImagePath;
                h.UserModel.UserImagePath = userImagePath;
            }
        }
    }
}