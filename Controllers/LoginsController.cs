using EmployeeManagementSystem2025.Models;
using EmployeeManagementSystem2025.Services;
using EmployeeManagementSystem2025.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2025.Controllers
{
    public class LoginsController : Controller
    {
        private readonly IUserService _userService;

        // Dependency Injection (Constructor)
        public LoginsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: https://localhost:5580/Logins/Login
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View(new LoginViewModel());
        }
        // POST: https://localhost:5580/Logins/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginVModel)
        {
            if (ModelState.IsValid)
            {
                User availableUser = _userService.AuthenticateUserNameAndPassword(
                    loginVModel.UserName, loginVModel.UserPassword
                );

                if (availableUser != null)
                {
                    Response.Cookies.Append("UserName", availableUser.UserName.ToString(),
                      new CookieOptions { Expires = DateTime.Now.AddHours(1) }
                        );
                    Response.Cookies.Append("RoleId", availableUser.RoleId.ToString(),
                    new CookieOptions { Expires = DateTime.Now.AddHours(1) }
                      );
                    TempData["SuccessMessage"] = $"Welcome,{availableUser.UserName}!";

                    
                    // With this line:
                    return RedirectToRoleBasedDashBoard(availableUser.RoleId);

                }
                TempData["ErrorMessage"] = "Invalid username or password.";
            }
            ViewData["Title"] = "Credentials";
            return View(loginVModel);


            //stores information in cookies
        }

        private IActionResult RedirectToRoleBasedDashBoard(int roleId )
        {
            switch (roleId)
            {
                case 1: return RedirectToAction("Index", "Admins");
                case 2: return RedirectToAction("Index", "Managers");
                case 3: return RedirectToAction("Index", "Receptionist");
                default: return RedirectToAction("Index", "Logins");
            }
        }
    }
}
