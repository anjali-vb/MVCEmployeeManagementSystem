using EmployeeManagementSystem2025.Models;
using EmployeeManagementSystem2025.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagementSystem2025.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        [HttpGet]
        public IActionResult List()
        {
            List<Employee> employees = _employeeService.GetAllEmployees().ToList(); 
            return View(employees);
        }
        #region 2 GET -- Displaying for Insert  --- 1 - Insert
        [HttpGet]
        public IActionResult Create()
        {
            //populating dropdown data for department -- viewData,ViewBag
           ViewBag.Departments= _employeeService.GetAllDepartments();
            return View();
        }

        #endregion

        #region 3 POST --- Inserting a new record for submit 2 -- insert 
        [HttpPost]
        public IActionResult Create([Bind] Employee employee)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _employeeService.AddEmployee(employee);
                    
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
           
        }
        #endregion
        #region $- GET --Displaying for update----1 UPDATE

        [HttpGet]
        public IActionResult Edit(int id)

        {
            //populating dropdown data for department --Viewdata ,viewbag
            ViewBag.Departments = _employeeService.GetAllDepartments();
            


            //GET a specefic employee
            Employee employee=_employeeService.GetEmployeeById(id);
            return View(employee);


        }

        #endregion


        #region 5 POST / PUT-- Updating for update ---- 2 UPDATE

        [HttpPost]
        public IActionResult Edit([Bind] int id,Employee employee)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.EditAndUpdateEmployee(employee);

                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }



        }
        #endregion
    }
}
