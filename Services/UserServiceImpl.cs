using EmployeeManagementSystem2025.Models;
using EmployeeManagementSystem2025.Repositories;
using EmployeeManagementSystem2025.Services;

namespace EmployeeManagementSystem2025.Service
{
    public class UserServiceImpl : IUserService
    {
        //field
        private readonly IUserRepository _userRepository;
        //DI
        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User AuthenticateUserNameAndPassword(string userName, string password)
        {
            return _userRepository.AuthenticateUser(userName, password);
        }
    }
}
