using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class MarkController
    {
        private readonly string _connectionString = "Data Source=unicomtic.db;Version=3;";

        // Add Mark
        public async Task<bool> AddMarkAsync(Mark mark)
        {
            if (mark.Score < 0 || mark.Score > 100)
                throw new ArgumentException("Score must be between 0 and 100");

            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "INSERT INTO Marks (StudentId, ExamId, Score, DateRecorded) VALUES (@studentId, @examId, @score, @dateRecorded)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", mark.StudentId);
                    cmd.Parameters.AddWithValue("@examId", mark.ExamId);
                    cmd.Parameters.AddWithValue("@score", mark.Score);
                    cmd.Parameters.AddWithValue("@dateRecorded", mark.DateRecorded.ToString("yyyy-MM-dd HH:mm:ss"));

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // Update Mark
        public async Task<bool> UpdateMarkAsync(Mark mark)
        {
            if (mark.Score < 0 || mark.Score > 100)
                throw new ArgumentException("Score must be between 0 and 100");

            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "UPDATE Marks SET StudentId=@studentId, ExamId=@examId, Score=@score, DateRecorded=@dateRecorded WHERE MarkId=@markId";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", mark.StudentId);
                    cmd.Parameters.AddWithValue("@examId", mark.ExamId);
                    cmd.Parameters.AddWithValue("@score", mark.Score);
                    cmd.Parameters.AddWithValue("@dateRecorded", mark.DateRecorded.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@markId", mark.MarkId);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // Delete Mark
        public async Task<bool> DeleteMarkAsync(int markId)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "DELETE FROM Marks WHERE MarkId=@markId";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@markId", markId);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }

        // Get All Marks
        public async Task<List<Mark>> GetAllMarksAsync()
        {
            var marks = new List<Mark>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                await conn.OpenAsync();
                string sql = "SELECT MarkId, StudentId, ExamId, Score, DateRecorded FROM Marks";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var mark = new Mark
                        {
                            MarkId = reader.GetInt32(0),
                            StudentId = reader.GetInt32(1),
                            ExamId = reader.GetInt32(2),
                            Score = reader.GetInt32(3),
                            DateRecorded = DateTime.Parse(reader.GetString(4))
                        };
                        marks.Add(mark);
                    }
                }
            }
            return marks;
        }
    }
}
