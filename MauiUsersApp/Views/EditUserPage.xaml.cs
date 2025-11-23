using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

public partial class EditUserPage : ContentPage
{
    public EditUserPage(EditUserViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}