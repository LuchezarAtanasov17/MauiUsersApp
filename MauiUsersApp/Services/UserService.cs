using Dapper;
using MauiUsersApp.Data;
using MauiUsersApp.Models;

namespace MauiUsersApp.Services;

/// <summary>
/// Represents user service.
/// </summary>
public class UserService : IUserService
{
    /// <inheritdoc/>
    public async Task<List<User>> ListUsersAsync()
    {
        using var connection = Database.GetConnection();

        string sql = "SELECT * FROM Users";

        IEnumerable<User> users = await connection
            .QueryAsync<User>(sql);

        var result = users.ToList();

        return result;
    }

    /// <inheritdoc/>
    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var connection = Database.GetConnection();

        string sql = "SELECT * FROM Users WHERE Id = @Id";

        User? result = await connection
            .QueryFirstOrDefaultAsync<User>(sql, new { Id = id });

        return result;
    }

    /// <inheritdoc/>
    public async Task<int> CreateUserAsync(User user)
    {
        using var connection = Database.GetConnection();

        string sql = @"INSERT INTO Users (Name, Email, Password, Username, Phone, IsActive)
                       VALUES (@Name, @Email, @Password, @Username, @Phone, @IsActive)";

        int affectedRows = await connection.ExecuteAsync(sql, user);

        return affectedRows;
    }

    /// <inheritdoc/>
    public async Task<int> UpdateUserAsync(User user)
    {
        using var connection = Database.GetConnection();

        string sql = @"UPDATE Users
                       SET Name=@Name, Email=@Email, Username=@Username, Phone=@Phone, IsActive=@IsActive
                       WHERE Id=@Id";

        int affectedRows = await connection.ExecuteAsync(sql, user);

        return affectedRows;
    }

    /// <inheritdoc/>
    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        using var connection = Database.GetConnection();

        string sql = @"SELECT * FROM Users
                        WHERE Email = @Email AND Password = @Password
                        LIMIT 1;";

        User? user = await connection
            .QueryFirstOrDefaultAsync<User>(sql, new { Email = email, Password = password });

        return user;
    }
}
