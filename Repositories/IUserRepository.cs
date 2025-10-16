using EmployeeManagementSystem2025.Models;

namespace EmployeeManagementSystem2025.Repositories
{
    public interface IUserRepository 
    {
        //Credentials
        User AuthenticateUser(string username, string password);
    }
}
