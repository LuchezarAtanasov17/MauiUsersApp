using Microsoft.Data.Sqlite;

namespace MauiUsersApp.Data;

public static class Database
{
    private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");

    public static void Initialize()
    {
        if (!File.Exists(dbPath))
        {
            using var connection = GetConnection();

            connection.Open();

            SqliteCommand tableCommand = connection.CreateCommand();

            tableCommand.CommandText =
                @"CREATE TABLE Users(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Username TEXT NOT NULL,
                        Phone TEXT,
                        Email TEXT,
                        Password TEXT,
                        IsActive INTEGER NOT NULL)";

            tableCommand.ExecuteNonQuery();
        }
    }

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection($"Data Source={dbPath}");
    }
}
