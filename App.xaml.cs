using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Pomocnik_Rozgrywek.Data;
using Microsoft.EntityFrameworkCore;
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
            var db = Database.Instance;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ICompetitionService, CompetitionService>();

            services.AddSingleton<MainWindow>();
        }

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            //DatabaseInitializer.Initialize();
           Database.LoadFromFile();
            mainView = new MainView();
            mainView.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Database.Instance.SaveToFile();
        }


    }

}
