namespace EmployeeManagementSystem2025.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
        public virtual Role? Role { get; set; }
    }
}
