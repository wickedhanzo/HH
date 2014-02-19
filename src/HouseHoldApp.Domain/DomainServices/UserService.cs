using System;
using HouseHoldApp.Domain.Repository;
using Microsoft.AspNet.Identity;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IUserService
    {
        void RegisterUser(User user);
        bool IsValidUser(User user, IPasswordHasher passwordHasher);
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

        public bool IsValidUser(User user, IPasswordHasher passwordHasher)
        {
            bool isValid = false;
            User userFound = _userRepository.FindByEmailAddress(user.EmailAddress);
            if (userFound != null)
            {
                isValid = passwordHasher.VerifyHashedPassword(userFound.Password, user.Password) == PasswordVerificationResult.Success;
            }
            return isValid;
        }
    }
}
