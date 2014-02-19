namespace HouseHoldApp.Domain.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User FindByEmailAddress(string emailAddress);
    }
}
