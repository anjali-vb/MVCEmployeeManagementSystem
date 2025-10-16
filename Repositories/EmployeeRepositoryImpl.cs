using EmployeeManagementSystem2025.Models;
using System.Data.SqlClient;

namespace EmployeeManagementSystem2025.Repositories
{
    public class EmployeeRepositoryImpl : IEmployeeRepository
    {
        private readonly string connectionString;

        //constructor
        public EmployeeRepositoryImpl(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MVCConnectionString");
        }
        #region select all employee 
        public IEnumerable<Employee> SelectAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["ID"].ToString());
                        employee.Name = reader["Name"].ToString();
                        employee.Gender = reader["Gender"].ToString();
                        employee.Designation = reader["Designation"].ToString();
                        employee.Salary = Convert.ToDecimal(reader["Salary"]);
                        employee.DOB = Convert.ToDateTime(reader["DOB"]);
                        employee.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());

                        employee.IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]);

                        employee.Department = new Department();
                        employee.Department.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                        //employee.Department.DepartmentName = reader["DepartmentName"].ToString();

                        employees.Add(employee);
                    }
                    con.Close();
                }
                return employees;
            }
        }

        #endregion
        #region search by employee id
        public Employee SelectEmployeeById(int? empId)

        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", empId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    employee.Id = Convert.ToInt32(dr["Id"].ToString());
                    employee.Name = dr["Name"].ToString();
                    employee.Gender = dr["Gender"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.Salary = Convert.ToDecimal(dr["Salary"]);
                    employee.DOB = Convert.ToDateTime(dr["DOB"]);
                    employee.DepartmentId = Convert.ToInt32(dr["DepartmentId"].ToString());


                }
                con.Close();

                return employee;
            }
        }
        



        #endregion
        #region list of departments
        public List<Department> SelectAllDepartments()
        {
            List<Department> departments = new List<Department>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SelectAllDepartments", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var department = new Department
                        {
                            DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                            DepartmentName = Convert.ToString(reader["DepartmentName"])
                        };
                        departments.Add(department);

                    }
                }
                con.Close();
            }
            return departments;
        }

        #endregion
        #region insert an employee
        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion
        #region 5 -update an employee
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EditEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        #endregion
    }
}