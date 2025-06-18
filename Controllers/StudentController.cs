using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController
    {
        private readonly string _connectionString = "Data Source=unicomtic.db;Version=3;";

        // ✅ Add Student
        public async Task<bool> AddStudentAsync(Student student)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "INSERT INTO Student (Name, Email, Gender, DOB, Phone, CourseId) VALUES (@name, @mail, @gender, @dob, @phone, @courseId)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@mail", student.Email ?? "");
                    cmd.Parameters.AddWithValue("@gender", student.Gender ?? "");
                    cmd.Parameters.AddWithValue("@dob", student.DOB.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@phone", student.Phone ?? "");
                    cmd.Parameters.AddWithValue("@courseId", student.CourseId);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // ✅ Update Student
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "UPDATE Student SET Name=@name, Email=@mail, Gender=@gender, DOB=@dob, Phone=@phone, CourseId=@courseId WHERE StudentId=@id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@mail", student.Email);
                    cmd.Parameters.AddWithValue("@gender", student.Gender);
                    cmd.Parameters.AddWithValue("@dob", student.DOB.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@phone", student.Phone);
                    cmd.Parameters.AddWithValue("@courseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@id", student.StudentId);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // ✅ Delete Student
        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "DELETE FROM Student WHERE StudentId=@id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // ✅ Get All Students
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "SELECT StudentId, Name, Email, Gender, DOB, Phone, CourseId FROM Student";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        students.Add(new Student
                        {
                            StudentId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Gender = reader.GetString(3),
                            DOB = DateTime.Parse(reader.GetString(4)),
                            Phone = reader.GetString(5),
                            CourseId = reader.GetInt32(6)
                        });
                    }
                }
            }
            return students;
        }
    }
}
