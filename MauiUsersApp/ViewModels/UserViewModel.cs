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
        UserSelectedCommand = new AsyncRelayCommand(OnUserSelected);
        AddUserCommand = new AsyncRelayCommand(OnAddUser);

        LoadUsersCommand.Execute(null);
    }

    [ObservableProperty]
    ObservableCollection<User> users;

    [ObservableProperty]
    User selectedUser;

    public IAsyncRelayCommand LoadUsersCommand { get; }

    public IAsyncRelayCommand UserSelectedCommand { get; }

    public IAsyncRelayCommand AddUserCommand { get; }


    private async Task LoadUsersAsync()
    {
        Users.Clear();

        List<User> users = await _userService.ListUsersAsync();

        foreach (var user in users)
        {
            Users.Add(user);
        }
    }

    private async Task OnUserSelected()
    {
        if (SelectedUser is null)
        {
            return;
        }

        int userId = SelectedUser.Id;

        SelectedUser = null;

        await Shell.Current.GoToAsync($"EditUserPage?UserId={userId}");
    }

    private async Task OnAddUser()
    {
        await Shell.Current.GoToAsync("EditUserPage");
    }
}