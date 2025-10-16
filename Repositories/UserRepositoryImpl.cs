using EmployeeManagementSystem2025.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem2025.Repositories
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepositoryImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MVCConnectionString");
        }

        public User AuthenticateUser(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        u.UserId, 
                        u.UserName, 
                        u.UserPassword, 
                        u.RoleId, 
                        u.IsActive, 
                        r.RoleName
                    FROM TblUsers u
                    JOIN TblRoles r ON u.RoleId = r.RoleId
                    WHERE u.UserName = @UserName 
                      AND u.UserPassword = @UserPassword
                      AND u.IsActive = 1;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@UserPassword", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                UserPassword = reader.GetString(2),
                                RoleId = reader.GetInt32(3),
                                IsActive = reader.GetBoolean(4),
                                Role = new Role
                                {
                                    RoleId = reader.GetInt32(3),
                                    RoleName = reader.GetString(5)
                                }
                            };
                        }
                    }
                }
            }

            //  Return null if no user found
            return null;
        }
    }
}