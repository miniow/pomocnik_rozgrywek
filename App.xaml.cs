using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Pomocnik_Rozgrywek.Data;
using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using Pomocnik_Rozgrywek.Repositories;
using Pomocnik_Rozgrywek.Services.Interfaces;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Views;

namespace Pomocnik_Rozgrywek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainView mainView;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<ICompetitonRepository, CompetitionRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
          //  services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ICompetitionService, CompetitionService>();

            services.AddSingleton<MainWindow>();
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            DbInitializer.Initialize(new ApplicationDbContext());
            mainView = new MainView();
            mainView.Show();
        }
    }

}
