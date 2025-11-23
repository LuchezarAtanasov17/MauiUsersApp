using MauiUsersApp.Views;

namespace MauiUsersApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("UsersPage", typeof(UsersPage));
            Routing.RegisterRoute("EditUserPage", typeof(EditUserPage));
        }
    }
}
