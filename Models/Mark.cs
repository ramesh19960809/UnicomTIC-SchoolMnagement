using System;

namespace YourNamespace.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
        public DateTime DateRecorded { get; set; }

        public Mark()
        {
            DateRecorded = DateTime.Now;
        }
    }
}
