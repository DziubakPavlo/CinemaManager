using CinemaManager.Repositories;
using CinemaManager.Services;
using CinemaManager.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        //Configure services and build the service provider
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddSingleton<IStorageContext, InMemoryStorageContext>();

            services.AddSingleton<IHallRepository, HallRepository>();
            services.AddSingleton<ISessionRepository, SessionRepository>();

            services.AddSingleton<IHallService, HallService>();
            services.AddSingleton<ISessionService, SessionService>();

            services.AddSingleton<MainWindow>();

            services.AddTransient<HallsPage>();
            services.AddTransient<AddHallPage>();
            services.AddTransient<HallDetailsPage>();
            services.AddTransient<AddSessionPage>();
            services.AddTransient<SessionDetailsPage>();

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
