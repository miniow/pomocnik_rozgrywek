using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Pomocnik_Rozgrywek.Data;
using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using Pomocnik_Rozgrywek.Repositories;

namespace Pomocnik_Rozgrywek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddScoped<ICompetitonRepository, CompetitionRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPearsonRepository, PearsonRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();

            services.AddSingleton<MainWindow>();
        }
    }

}
