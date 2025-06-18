using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Repositories;

namespace StudentManagementSystem.Controllers
{
    public class UserController
    {
        // Add new user
        public async Task<bool> AddUserAsync(User user)
        {
            string query = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
            var parameters = new Dictionary<string, object>
            {
                { "@username", user.Username },
                { "@password", user.Password },
                { "@role", user.Role }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // Update user
        public async Task<bool> UpdateUserAsync(User user)
        {
            string query = "UPDATE Users SET Username = @username, Password = @password, Role = @role WHERE UserID = @userID";
            var parameters = new Dictionary<string, object>
            {
                { "@username", user.Username },
                { "@password", user.Password },
                { "@role", user.Role },
                { "@userID", user.UserID }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // Delete user
        public async Task<bool> DeleteUserAsync(int userID)
        {
            string query = "DELETE FROM Users WHERE UserID = @userID";
            var parameters = new Dictionary<string, object>
            {
                { "@userID", userID }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // Get all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            string query = "SELECT * FROM Users";
            DataTable dt = await DatabaseManager.ExecuteQueryAsync(query);

            List<User> userList = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                User user = new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString()
                };
                userList.Add(user);
            }

            return userList;
        }

        // Get user by ID
        public async Task<User> GetUserByIdAsync(int userID)
        {
            string query = "SELECT * FROM Users WHERE UserID = @userID";
            var parameters = new Dictionary<string, object>
            {
                { "@userID", userID }
            };

            DataTable dt = await DatabaseManager.ExecuteQueryAsync(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString()
                };
            }

            return null;
        }
    }
}
