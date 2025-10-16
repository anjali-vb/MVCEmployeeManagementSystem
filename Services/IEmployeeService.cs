using EmployeeManagementSystem2025.Models;

namespace EmployeeManagementSystem2025.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int? empId);

        List<Department> GetAllDepartments();

        void AddEmployee(Employee employee);

        //5-Edit employee
        void EditAndUpdateEmployee(Employee employee);


    }
}
