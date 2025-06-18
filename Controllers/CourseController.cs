using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTICManagementSystem.Models;  // Course model namespace

namespace UnicomTICManagementSystem.Controllers
{
    public class CourseController
    {
        private readonly string _connectionString = "Data Source=Unicom.db;Version=3;";

        // Add Course
        public bool AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
                throw new ArgumentException("Course name is required");

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Courses (CourseName, Description, DurationMonths) VALUES (@name, @desc, @duration)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@desc", course.Description ?? "");
                    cmd.Parameters.AddWithValue("@duration", course.DurationMonths);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Update Course
        public bool UpdateCourse(Course course)
        {
            if (course.CourseId <= 0)
                throw new ArgumentException("Invalid CourseId");

            if (string.IsNullOrWhiteSpace(course.CourseName))
                throw new ArgumentException("Course name is required");

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Courses SET CourseName=@name, Description=@desc, DurationMonths=@duration WHERE CourseId=@id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@desc", course.Description ?? "");
                    cmd.Parameters.AddWithValue("@duration", course.DurationMonths);
                    cmd.Parameters.AddWithValue("@id", course.CourseId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Delete Course
        public bool DeleteCourse(int courseId)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Courses WHERE CourseId=@id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", courseId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Get All Courses
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT CourseId, CourseName, DurationMonths FROM Courses"; // Removed Description
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetInt32(0),
                            CourseName = reader.GetString(1),
                            Description = "", // Set default value since column is missing
                            DurationMonths = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)
                        });
                    }
                }
            }

            return courses;
        }
    }
}
