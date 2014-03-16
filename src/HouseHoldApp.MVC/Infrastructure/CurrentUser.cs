using System.Security.Principal;
using System.Web.ModelBinding;
using System.Web.SessionState;
using HouseHoldApp.Domain.DomainServices;
using Microsoft.AspNet.Identity;
using System.Web;

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
        private readonly ISessionHelper _sessionHelper;
        public CurrentUser(IIdentity identity,
                           IHouseHoldMemberService houseHoldMemberService,
                           ISessionHelper sessionHelper)
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
                int houseHoldId = _sessionHelper.HouseHoldId ?? _houseHoldMemberService.GetByUserId(UserId).HouseHoldId;
                _sessionHelper.HouseHoldId = houseHoldId;
                HouseHoldId = houseHoldId;
        }

        public virtual string UserName { get; private set; }
        public virtual bool IsAuthenticated { get; private set; }
        public virtual string UserId { get; private set; }
        public int? HouseHoldId { get; set; }
    }
}