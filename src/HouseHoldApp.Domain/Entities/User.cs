namespace HouseHoldApp.Domain.Entities
{
    public class User : EntityBase
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
