using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}