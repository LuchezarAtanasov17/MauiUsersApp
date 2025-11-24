using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

/// <summary>
/// Represetns the login page.
/// </summary>
public partial class LoginPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginPage"/> class.
    /// </summary>
    /// <param name="vm">the login view model.</param>
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}