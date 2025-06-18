using System;
using System.Data.SQLite;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class LoginController
    {
        // ✅ Validate username + password for login
        public bool ValidateLogin(string username, string password)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // ✅ Check if a username already exists
        public bool UserExists(string username)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // ✅ Add a new user (only if username does not exist)
        public bool AddUser(string username, string password, string role)
        {
            if (UserExists(username))
            {
                return false; // Username already taken
            }

            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // ✅ Get user role after login
        public string GetUserRole(string username)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT Role FROM Users WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    var role = cmd.ExecuteScalar();
                    return role != null ? role.ToString() : "";
                }
            }
        }
    }
}
