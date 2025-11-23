using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

public partial class UsersPage : ContentPage
{
    public UsersPage(UsersViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is UsersViewModel vm)
        {
            vm.LoadUsersCommand.Execute(null);
        }
    }
}