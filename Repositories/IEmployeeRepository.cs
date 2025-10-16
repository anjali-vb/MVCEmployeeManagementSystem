using EmployeeManagementSystem2025.Models;

namespace EmployeeManagementSystem2025.Repositories
{
    public interface IEmployeeRepository
    {
        //1-list of Employees - select, insert , update
        IEnumerable<Employee> SelectAllEmployees();

        //2-search by employee id
        Employee SelectEmployeeById(int? empId);

        //3-list of departments
        List<Department> SelectAllDepartments();

        //4 -insert an employee --- Insert --- post---404 notfound --200 ok
        void InsertEmployee(Employee employee);    
        
        //5- Edit and update
        void UpdateEmployee(Employee employee);



    }
}
