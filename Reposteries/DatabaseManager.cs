using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Repositories
{
    public class DatabaseManager
    {
        private static readonly string connectionString = "Data Source=Unicom.db;Version=3;";

        // Always return NEW connection instead of reusing static connection
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string createUsersTable = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );";
                string createSubjectsTable = @"CREATE TABLE IF NOT EXISTS Courses (
                    CourseId INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL,
                    Description TEXT,
                    DurationMonths INTEGER
                );";

                string createCoursesTable = @"CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                );";

                string createStudentsTable = @"CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    CourseID INTEGER,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                );";

                string createExamsTable = @"CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    SubjectID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
                );";

                string createMarksTable = @"CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER,
                    ExamID INTEGER,
                    Score INTEGER,
                    FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
                );";

                string createRoomsTable = @"CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomName TEXT NOT NULL,
                    RoomType TEXT NOT NULL
                );";

                string createTimetablesTable = @"CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectID INTEGER,
                    TimeSlot TEXT NOT NULL,
                    RoomID INTEGER,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
                    FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID)
                );";

                // Execute all CREATE TABLE commands
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = createUsersTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createCoursesTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createSubjectsTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createStudentsTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createExamsTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createMarksTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createRoomsTable; cmd.ExecuteNonQuery();
                cmd.CommandText = createTimetablesTable; cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void ExecuteNonQuery(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static DataTable ExecuteQuery(string query, params SQLiteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        // ✅ Async method with Dictionary parameters
        internal static async Task<DataTable> ExecuteQueryAsync(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        internal static async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    int result = await cmd.ExecuteNonQueryAsync();
                    connection.Close();
                    return result;
                }
            }
        }

        // ✅ Async method without parameters
        internal static async Task<DataTable> ExecuteQueryAsync(string query)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
                connection.Close();
            }
            return dt;
        }
    }
}
