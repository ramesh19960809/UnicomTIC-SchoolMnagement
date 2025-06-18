using System.Data.SQLite;

namespace UnicomTICManagementSystem.Repositories
{
    public class Dbcon
    {
        private static readonly string connectionString = "Data Source=Unicom.db;Version=3;";

        // This method returns a **new connection every time**, to avoid object reuse issues
        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            return conn;
        }
    }
}
