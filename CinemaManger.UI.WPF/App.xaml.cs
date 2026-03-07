using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IStorageService, StorageService>();
            ServiceProvider = services.BuildServiceProvider();

            base.OnStartup(e);
        }
    }

}
