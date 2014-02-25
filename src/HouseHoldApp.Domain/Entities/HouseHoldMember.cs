namespace HouseHoldApp.Domain.Entities
{
    public class HouseHoldMember : User
    {
        public HouseHold HouseHold { get; set; }
    }
}
