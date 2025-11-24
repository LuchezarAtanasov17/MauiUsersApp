using Dapper;
using Microsoft.Data.Sqlite;

namespace MauiUsersApp.Data;

public static class Database
{
    private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");

    public static void Initialize()
    {
        using var connection = GetConnection();

        connection.Open();

        connection.Execute(@"CREATE TABLE IF NOT EXISTS Users(
                             Id INTEGER PRIMARY KEY AUTOINCREMENT,
                             Name TEXT NOT NULL,
                             Username TEXT NOT NULL,
                             Phone TEXT,
                             Email TEXT,
                             Password TEXT,
                             IsActive INTEGER NOT NULL);");

        var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users");

        if (count == 0)
        {
            connection.Execute(@"INSERT INTO Users (Name, Username, Email, Phone, Password, IsActive)
                                    VALUES ('Test User 1', 'testuser1', 'test1@example.com', '1111111111', '123', 1),
                                            ('Test User 2', 'testuser2', 'test2@example.com', '2222222222', '123', 1),
                                            ('Test User 3', 'testuser3', 'test3@example.com', '3333333333', '123', 0)");
        }
    }

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection($"Data Source={dbPath}");
    }
}
