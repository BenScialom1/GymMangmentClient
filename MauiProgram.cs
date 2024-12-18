using GymMangmentClient.Services;
using GymMangmentClient.ViewModels;
using GymMangmentClient.Views;
using Microsoft.Extensions.Logging;

namespace GymMangmentClient
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
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<RegisterPageViewModel>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddSingleton<GymMangmentWebApi>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
