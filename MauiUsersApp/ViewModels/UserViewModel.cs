using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUsersApp.Models;
using MauiUsersApp.Services;
using System.Collections.ObjectModel;

namespace MauiUsersApp.ViewModels;

public partial class UsersViewModel : ObservableObject
{
    private readonly IUserService _userService;

    public UsersViewModel(IUserService userService)
    {
        _userService = userService;

        users = new ObservableCollection<User>();

        LoadUsersCommand = new AsyncRelayCommand(LoadUsersAsync);

        LoadUsersCommand.Execute(null);
    }

    [ObservableProperty]
    ObservableCollection<User> users;

    public IAsyncRelayCommand LoadUsersCommand { get; }

    private async Task LoadUsersAsync()
    {
        Users.Clear();

        List<User> users = await _userService.ListUsersAsync();

        foreach (var user in users)
        {
            Users.Add(user);
        }
    }
}