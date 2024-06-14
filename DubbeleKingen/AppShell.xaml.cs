using DubbeleKingen.Pages;
using System.Security.Cryptography.X509Certificates;

namespace DubbeleKingen
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PlayerCountSelectPage), typeof(PlayerCountSelectPage));
            Routing.RegisterRoute(nameof(PlayerSelectPage), typeof(PlayerSelectPage));
            Routing.RegisterRoute(nameof(CreateNewPlayerPage), typeof(CreateNewPlayerPage));
            Routing.RegisterRoute(nameof(LoadGamePage), typeof(LoadGamePage));
            Routing.RegisterRoute(nameof(LeaderboardPage), typeof(LeaderboardPage));
            Routing.RegisterRoute(nameof(ChooseNamePage), typeof(ChooseNamePage));
            Routing.RegisterRoute(nameof(PositiveNegativePage), typeof(PositiveNegativePage));
            Routing.RegisterRoute(nameof(PickASuitPage), typeof(PickASuitPage));
            Routing.RegisterRoute(nameof(PickANegativePage), typeof(PickANegativePage));
            Routing.RegisterRoute(nameof(GameRunningPage), typeof(GameRunningPage));
            //Routing.RegisterRoute(nameof(ScorePage), typeof(ScorePage));
            Routing.RegisterRoute(nameof(SimpleScorePage), typeof(SimpleScorePage));
            Routing.RegisterRoute(nameof(GameLeaderboardPage), typeof(GameLeaderboardPage));
            Routing.RegisterRoute(nameof(ScoreLoadGamePage), typeof(ScoreLoadGamePage));
            Routing.RegisterRoute(nameof(ScoreLeaderboardPage), typeof(ScoreLeaderboardPage));

        }
    }
}
