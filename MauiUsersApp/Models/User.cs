namespace MauiUsersApp.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets if the user is active or not.
    /// </summary>
    public bool IsActive { get; set; }
}
