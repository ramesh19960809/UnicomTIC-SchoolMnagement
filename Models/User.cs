using System;

namespace StudentManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }          // Primary Key
        public string Username { get; set; }     // Login Name
        public string Password { get; set; }     // Plain text Password (as per spec)
        public string Role { get; set; }         // Admin, Staff, Student, or Lecturer
    }
}
