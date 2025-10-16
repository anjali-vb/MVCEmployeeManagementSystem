using EmployeeManagementSystem2025.Models;
using EmployeeManagementSystem2025.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2025.Controllers
{
    public class EmpModalController : Controller
    {
        // GET: EmpModalController
        private readonly IEmployeeService _employeeService;


        //DI
        public EmpModalController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public ActionResult Index() //Listing employees
        {
            //Populate Viewbag for Department
            ViewBag.Departments=_employeeService.GetAllDepartments();

            List<Employee>employees = _employeeService.GetAllEmployees().ToList();
            return View(employees);
        }

        // GET: EmpModalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpModalController/Create

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpModalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.AddEmployee(emp);

                }
                return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

                // GET: EmpModalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpModalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpModalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpModalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
