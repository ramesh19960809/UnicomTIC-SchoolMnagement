using System;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }       // PRIMARY KEY
        public string Name { get; set; }         // Student name
        public string Email { get; set; }        // Email ID
        public string Gender { get; set; }       // Male / Female
        public DateTime DOB { get; set; }        // Date of birth
        public string Phone { get; set; }        // Mobile Number
        public int CourseId { get; set; }        // Foreign Key (Course)
    }
}
