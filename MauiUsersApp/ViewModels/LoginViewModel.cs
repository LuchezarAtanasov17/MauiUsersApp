using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUsersApp.Services;

namespace MauiUsersApp.ViewModels;

/// <summary>
/// Represents login view model.
/// </summary>
/// <param name="userService">the user service</param>
public partial class LoginViewModel(IUserService userService) 
    : ObservableObject
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    [ObservableProperty]
    string email;

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [ObservableProperty]
    string password;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter both email and password.", "OK");
            return;
        }

        var user = await _userService.GetUserByEmailAndPasswordAsync(Email, Password);

        if (user == null)
        {
            await Shell.Current.DisplayAlert("Login failed", "Invalid email or password.", "OK");

            return;
        }

        await Shell.Current.GoToAsync("/UsersPage");
    }
}