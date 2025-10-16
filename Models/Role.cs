using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem2025.Models
{
    public class Role
    {
        [Key]

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public bool? IsActive { get; set; }

        


    }
}
