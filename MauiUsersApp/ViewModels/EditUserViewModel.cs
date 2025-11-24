using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUsersApp.Models;
using MauiUsersApp.Services;

namespace MauiUsersApp.ViewModels;

/// <summary>
/// Represents user view model
/// </summary>
/// <param name="userService">the user service</param>
[QueryProperty(nameof(UserId), "UserId")]
public partial class EditUserViewModel(IUserService userService)
    : ObservableObject
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Gets or sets the user ID.
    /// </summary>
    [ObservableProperty]
    int userId;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [ObservableProperty]
    string name;

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [ObservableProperty]
    string username;

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    [ObservableProperty]
    string email;

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    [ObservableProperty]
    string phone;

    /// <summary>
    /// Gets or sets if the user is active or not.
    /// </summary>
    [ObservableProperty]
    bool isActive;

    /// <summary>
    /// Gets the title depending on whether the user is being created or edited.
    /// </summary>
    public string Title => UserId == 0 ? "Add User" : "Edit User";

    /// <summary>
    /// Gets if the page is in edit mode.
    /// </summary>
    public bool IsEditMode => UserId > 0;

    /// <summary>
    /// Called when the user ID is changed. Loads the user data updates UI properties.
    /// </summary>
    /// <param name="id"></param>
    partial void OnUserIdChanged(int id)
    {
        LoadUser(id);
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(IsEditMode));
    }

    private async void LoadUser(int id)
    {
        User? user = await _userService.GetUserByIdAsync(id);

        if (user is null)
        {
            return;
        }

        Name = user.Name;
        Username = user.Username;
        Email = user.Email;
        Phone = user.Phone;
        IsActive = user.IsActive;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        var user = new User
        {
            Id = UserId,
            Name = Name,
            Username = Username,
            Email = Email,
            Phone = Phone,
            IsActive = IsActive
        };

        if (UserId == 0)
        {
            await _userService.CreateUserAsync(user);
        }
        else
        {
            await _userService.UpdateUserAsync(user);
        }

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Delete User",
            "Are you sure you want to delete this user?",
            "Yes", "No");

        if (!confirm)
        {
            return;
        }

        await _userService.DeleteUserAsync(UserId);

        await Shell.Current.DisplayAlert("Deleted", "User was deleted.", "OK");

        await Shell.Current.GoToAsync("/UsersPage");
    }
}