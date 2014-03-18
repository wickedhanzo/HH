using System.Security.Principal;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.MVC.Infrastructure
{
    public interface ICurrentUser
    {
        string UserName { get; }
        bool IsAuthenticated { get; }
        string UserId { get; }
        int? HouseHoldId { get; set; }
    }

    public class CurrentUser : ICurrentUser
    {
        private readonly IHouseHoldMemberService _houseHoldMemberService;
        private readonly ISessionStorage _sessionHelper;
        public CurrentUser(IIdentity identity,
                           IHouseHoldMemberService houseHoldMemberService,
                           ISessionStorage sessionHelper)
        {
            _houseHoldMemberService = houseHoldMemberService;
            _sessionHelper = sessionHelper;
            IsAuthenticated = identity.IsAuthenticated;
            UserName = identity.GetUserName();
            UserId = identity.GetUserId();
            SetHouseHold();
        }

        private void SetHouseHold()
        {
            int? houseHoldId;
            HouseHoldMember houseHoldMember = _houseHoldMemberService.GetByUserId(UserId);
            if (houseHoldMember == null)
            {
                houseHoldId = null;
            }
            else
            {
                houseHoldId = _sessionHelper.HouseHoldId ?? houseHoldMember.HouseHoldId;
            }
            _sessionHelper.HouseHoldId = houseHoldId;
            HouseHoldId = houseHoldId;
        }

        public virtual string UserName { get; private set; }
        public virtual bool IsAuthenticated { get; private set; }
        public virtual string UserId { get; private set; }
        public virtual int? HouseHoldId { get; set; }
    }
}