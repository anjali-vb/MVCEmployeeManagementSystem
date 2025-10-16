using EmployeeManagementSystem2025.Models;

namespace EmployeeManagementSystem2025.Services
{
    public interface IUserService

    {
        //Business Logic credentials

        User AuthenticateUserNameAndPassword(string userName, string password);
    }
}
