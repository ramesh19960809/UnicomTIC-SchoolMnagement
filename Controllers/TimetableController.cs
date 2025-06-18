using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_SchoolMnagement.Models;
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class TimetableController
    {
        // Get all Timetable records
        public List<TimeTable> GetAllTimetables()
        {
            List<TimeTable> timetables = new List<TimeTable>();

            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = @"SELECT TimetableID, CourseID, SubjectID, RoomID FROM Timetable";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeTable t = new TimeTable
                            {
                                TimetableID = Convert.ToInt32(reader["TimetableID"]),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                RoomID = Convert.ToInt32(reader["RoomID"]),

                            };
                            timetables.Add(t);
                        }
                    }
                }
            }
            return timetables;
        }

        // Add new Timetable record
        public bool AddTimetable(TimeTable timetable)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Timetable (CourseID, SubjectID, RoomID) 
                 VALUES (@CourseID, @SubjectID, @RoomID)";


                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Update Timetable record
        public bool UpdateTimetable(TimeTable timetable)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Timetable 
                 SET CourseID = @CourseID, SubjectID = @SubjectID, RoomID = @RoomID 
                 WHERE TimetableID = @TimetableID";


                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    cmd.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Delete Timetable by ID
        public bool DeleteTimetable(int timetableID)
        {
            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Timetable WHERE TimetableID = @TimetableID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TimetableID", timetableID);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Get Timetable by ID (optional)
        public TimeTable GetTimetableById(int timetableID)
        {
            TimeTable timetable = null;

            using (SQLiteConnection conn = Dbcon.GetConnection())
            {
                conn.Open();
                string query = "SELECT TimetableID, CourseID, SubjectID, RoomID FROM Timetable WHERE TimetableID = @TimetableID";


                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TimetableID", timetableID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            timetable = new TimeTable
                            {
                                TimetableID = Convert.ToInt32(reader["TimetableID"]),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                RoomID = Convert.ToInt32(reader["RoomID"]),
                                
                            };
                        }
                    }
                }
            }
            return timetable;
        }
    }
}
