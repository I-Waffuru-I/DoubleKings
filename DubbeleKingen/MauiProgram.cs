using CommunityToolkit.Maui;
using DubbeleKingen.Managers;
using DubbeleKingen.Pages;
using DubbeleKingen.Services;
using DubbeleKingen.ViewModels;
using Microsoft.Extensions.Logging;

namespace DubbeleKingen
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            
            
            // PAGES
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<PlayerCountSelectPage>();
            builder.Services.AddTransient<PlayerSelectPage>();
            builder.Services.AddTransient<CreateNewPlayerPage>();
            builder.Services.AddSingleton<LoadGamePage>();
            builder.Services.AddSingleton<LeaderboardPage>();
            builder.Services.AddSingleton<ChooseNamePage>();
            builder.Services.AddSingleton<PositiveNegativePage>();
            builder.Services.AddTransient<PickASuitPage>();
            builder.Services.AddTransient<PickANegativePage>();
            builder.Services.AddTransient<GameRunningPage>();
            builder.Services.AddTransient<ScorePage>();
            builder.Services.AddTransient<SimpleScorePage>();
            builder.Services.AddTransient<GameLeaderboardPage>();

            // MODELS
            builder.Services.AddSingleton<MainMenuModel>();
            builder.Services.AddSingleton<PlayerCountSelectModel>();
            builder.Services.AddSingleton<PlayerSelectModel>();
            builder.Services.AddSingleton<CreateNewPlayerModel>();
            builder.Services.AddSingleton<LoadGameModel>();
            builder.Services.AddSingleton<LeaderboardModel>();
            builder.Services.AddSingleton<ChooseNameModel>();
            builder.Services.AddSingleton<PositiveNegativeModel>();
            builder.Services.AddSingleton<PickASuitModel>();
            builder.Services.AddSingleton<PickANegativeModel>();
            builder.Services.AddSingleton<GameRunningModel>();
            builder.Services.AddSingleton<ScoreModel>();
            builder.Services.AddSingleton<GameLeaderboardModel>();

            // SERVICES
            builder.Services.AddSingleton<PlayerService>();
            builder.Services.AddSingleton<GameService>();

            // OTHER
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<NavigationManager>();
            builder.Services.AddSingleton<KingGameManager>();



#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}