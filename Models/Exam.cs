using System;

namespace StudentManagementSystem.Models
{
    public class Exam
    {
        
        public int ExamID { get; set; }

        
        public int CourseID { get; set; }

        
        public DateTime ExamDate { get; set; }

        
        public string ExamType { get; set; }
    }
}
