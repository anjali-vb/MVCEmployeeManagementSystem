using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem2025.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
