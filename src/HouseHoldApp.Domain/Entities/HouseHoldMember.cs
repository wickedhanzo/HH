namespace HouseHoldApp.Domain.Entities
{
    public class HouseHoldMember : EntityBase
    {
        public HouseHold HouseHold { get; set; }
        public int HouseHoldId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
