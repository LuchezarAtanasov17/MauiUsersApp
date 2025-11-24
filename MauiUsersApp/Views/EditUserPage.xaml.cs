using MauiUsersApp.ViewModels;

namespace MauiUsersApp.Views;

/// <summary>
/// Represents the edit user page.
/// </summary>
public partial class EditUserPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EditUserPage"/> class.
    /// </summary>
    /// <param name="vm">the user view model</param>
    public EditUserPage(EditUserViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}