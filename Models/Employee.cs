using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem2025.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        // Name: required, 3–30 chars, only letters & spaces
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }

        // Designation: required, up to 30 chars
        [Required(ErrorMessage = "Designation is required")]
        [StringLength(30, ErrorMessage = "Designation cannot exceed 30 characters")]
        public string Designation { get; set; }

        // Salary: required, must be positive
        [Required(ErrorMessage = "Salary is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than zero")]
        public decimal Salary { get; set; } 

        // DOB: required, must be a past date
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        // Department foreign key
        [ForeignKey(nameof(Department))]
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public bool IsActive { get; set; }

        // Navigation property
        public virtual Department? Department { get; set; }

        // Gender: required, limited values
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female or Other.")]
        public string Gender { get; set; }
    }
}
