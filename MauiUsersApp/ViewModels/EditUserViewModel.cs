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

    partial void OnUserIdChanged(int id)
    {
        LoadUser(id);
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
        var updated = new User
        {
            Id = UserId,
            Name = Name,
            Username = Username,
            Email = Email,
            Phone = Phone,
            IsActive = IsActive
        };

        await _userService.UpdateUserAsync(updated);

        await Shell.Current.GoToAsync("..");
    }
}