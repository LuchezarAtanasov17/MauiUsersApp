using MauiUsersApp.Models;

namespace MauiUsersApp.Services;

/// <summary>
/// Represents service for managing users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Lists users.
    /// </summary>
    /// <returns>the users</returns>
    Task<List<User>> ListUsersAsync();

    /// <summary>
    /// Gets a specified user by ID.
    /// </summary>
    /// <param name="id">the specified ID</param>
    /// <returns>the user</returns>
    Task<User?> GetUserByIdAsync(int id);
    
    /// <summary>
    /// Creates a user.
    /// </summary>
    /// <param name="user">the user</param>
    /// <returns>the number of affected rows</returns>
    Task<int> CreateUserAsync(User user);
    
    /// <summary>
    /// Updates a user.
    /// </summary>
    /// <param name="user">the user</param>
    /// <returns>the number of affected rows</returns>
    Task<int> UpdateUserAsync(User user);
}
