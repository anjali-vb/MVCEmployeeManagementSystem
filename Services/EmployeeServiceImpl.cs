using EmployeeManagementSystem2025.Models;
using EmployeeManagementSystem2025.Repositories;

namespace EmployeeManagementSystem2025.Services
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServiceImpl(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.SelectAllEmployees();
                
        }

        public Employee GetEmployeeById(int? empId)
        {
            return _employeeRepository.SelectEmployeeById(empId);
         }
        public List<Department> GetAllDepartments()
        {
            return _employeeRepository.SelectAllDepartments();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.InsertEmployee(employee);
        }


        //update an employee
        public void EditAndUpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);

        }
    }
}
