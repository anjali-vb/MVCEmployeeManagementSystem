using System.Diagnostics;
using System.Data.SqlClient;
using EmployeeManagementSystem2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly string connectionString;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var isConnected = TestConnection();//Ture or false
            return View((object)isConnected.ToString());
           //model =(object) isConnected.ToString()
        }
        private bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;

                }
            }
            catch(Exception ex) 
            {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
