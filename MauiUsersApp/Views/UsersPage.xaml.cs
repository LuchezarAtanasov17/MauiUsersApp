using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

public partial class UsersPage : ContentPage
{
    public UsersPage(UsersViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}