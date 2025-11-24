using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUsersApp.Models;
using MauiUsersApp.Services;
using System.Collections.ObjectModel;

namespace MauiUsersApp.ViewModels;

/// <summary>
/// Represents user view model.
/// </summary>
public partial class UsersViewModel : ObservableObject
{
    private readonly IUserService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
    /// </summary>
    /// <param name="userService">the user service</param>
    public UsersViewModel(IUserService userService)
    {
        _userService = userService;

        users = new ObservableCollection<User>();

        LoadUsersCommand = new AsyncRelayCommand(LoadUsersAsync);
        UserSelectedCommand = new AsyncRelayCommand(OnUserSelected);
        AddUserCommand = new AsyncRelayCommand(OnAddUser);

        LoadUsersCommand.Execute(null);
    }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<User> users;

    /// <summary>
    /// Gets or sets the selected user.
    /// </summary>
    [ObservableProperty]
    User selectedUser;

    /// <summary>
    /// Gets the command that loads users.
    /// </summary>
    public IAsyncRelayCommand LoadUsersCommand { get; }

    /// <summary>
    /// Gets the command that gets the selected user.
    /// </summary>
    public IAsyncRelayCommand UserSelectedCommand { get; }

    /// <summary>
    /// Gets the command that adds user.
    /// </summary>
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