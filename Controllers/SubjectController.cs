using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_SchoolMnagement.Models;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class SubjectController
    {
        // Get all subjects from DB
        public static List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT SubjectID, SubjectName, CourseID FROM Subjects";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            });
                        }
                    }
                }
            }
            return subjects;
        }

        // Add new Subject
        public bool AddSubject(Subject subject)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Update existing Subject
        public bool UpdateSubject(Subject subject)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Subjects SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", subject.SubjectID);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Delete Subject by ID
        public bool DeleteSubject(int subjectID)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Get Subject by ID (optional helper method)
        public Subject GetSubjectById(int subjectID)
        {
            Subject subject = null;

            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT SubjectID, SubjectName, CourseID FROM Subjects WHERE SubjectID = @SubjectID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject = new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            };
                        }
                    }
                }
            }

            return subject;
        }
    }
}
