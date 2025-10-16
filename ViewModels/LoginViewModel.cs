using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem2025.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }

    }
}