using System;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IUserService
    {
        void RegisterUser(User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            _userRepository.Add(user);
        }
    }
}
