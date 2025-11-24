using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUsersApp.Models;
using MauiUsersApp.Services;

namespace MauiUsersApp.ViewModels;

[QueryProperty(nameof(UserId), "UserId")]
public partial class EditUserViewModel(IUserService userService)
    : ObservableObject
{
    private readonly IUserService _userService = userService;

    [ObservableProperty]
    int userId;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string username;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string phone;

    [ObservableProperty]
    bool isActive;

    public string Title => UserId == 0 ? "Add User" : "Edit User";

    public bool IsEditMode => UserId > 0;

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