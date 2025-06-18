using StudentManagementSystem.Models;
using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnicomTIC_SchoolMnagement.Models;
using UnicomTICManagementSystem.Repositories;

namespace StudentManagementSystem.Controllers
{
    public class ExamController
    {
        // 1. Add New Exam
        public async Task<bool> AddExamAsync(Exam exam)
        {
            string query = "INSERT INTO Exams (CourseID, ExamDate, ExamType) VALUES (@courseID, @examDate, @examType)";
            var parameters = new Dictionary<string, object>
            {
                { "@courseID", exam.CourseID },
                { "@examDate", exam.ExamDate },
                { "@examType", exam.ExamType }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // 2. Update Existing Exam
        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            string query = "UPDATE Exams SET CourseID = @courseID, ExamDate = @examDate, ExamType = @examType WHERE ExamID = @examID";
            var parameters = new Dictionary<string, object>
            {
                { "@courseID", exam.CourseID },
                { "@examDate", exam.ExamDate },
                { "@examType", exam.ExamType },
                { "@examID", exam.ExamID }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // 3. Delete Exam by ID
        public async Task<bool> DeleteExamAsync(int examID)
        {
            string query = "DELETE FROM Exams WHERE ExamID = @examID";
            var parameters = new Dictionary<string, object>
            {
                { "@examID", examID }
            };

            int result = await DatabaseManager.ExecuteNonQueryAsync(query, parameters);
            return result > 0;
        }

        // 4. Get All Exams
        public async Task<List<Exam>> GetAllExamsAsync()
        {
            string query = "SELECT * FROM Exams";
            DataTable dt = await DatabaseManager.ExecuteQueryAsync(query);

            List<Exam> examList = new List<Exam>();
            foreach (DataRow row in dt.Rows)
            {
                Exam exam = new Exam
                {
                    ExamID = Convert.ToInt32(row["ExamID"]),
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    ExamDate = Convert.ToDateTime(row["ExamDate"]),
                    ExamType = row["ExamType"].ToString()
                };
                examList.Add(exam);
            }

            return examList;
        }

        // 5. Get Exam by ID
        public async Task<Exam> GetExamByIdAsync(int examID)
        {
            string query = "SELECT * FROM Exams WHERE ExamID = @examID";
            var parameters = new Dictionary<string, object>
            {
                { "@examID", examID }
            };

            DataTable dt = await DatabaseManager.ExecuteQueryAsync(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Exam
                {
                    ExamID = Convert.ToInt32(row["ExamID"]),
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    ExamDate = Convert.ToDateTime(row["ExamDate"]),
                    ExamType = row["ExamType"].ToString()
                };
            }

            return null;
        }
    }
}
