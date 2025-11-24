using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

/// <summary>
/// Represents users page.
/// </summary>
public partial class UsersPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersPage"/> class.
    /// </summary>
    /// <param name="vm">the users view model</param>
    public UsersPage(UsersViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    /// <summary>
    /// Called when the page becomes visible. Reloads the user list.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is UsersViewModel vm)
        {
            vm.LoadUsersCommand.Execute(null);
        }
    }
}