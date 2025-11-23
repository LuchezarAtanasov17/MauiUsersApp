using MauiUsersApp.Data;
using MauiUsersApp.Services;
using MauiUsersApp.ViewModels;
using MauiUsersApp.Views;
using Microsoft.Extensions.Logging;

namespace MauiUsersApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            Database.Initialize();

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<UsersViewModel>();
            builder.Services.AddSingleton<UsersPage>();
            builder.Services.AddTransient<EditUserViewModel>();
            builder.Services.AddTransient<EditUserPage>();

            return builder.Build();
        }
    }
}
