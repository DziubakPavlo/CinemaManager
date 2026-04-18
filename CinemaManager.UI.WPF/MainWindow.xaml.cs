using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        //Main window constructor
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            //Navigate to the HallsPage on startup
            NavigateToHalls();
        }

        private void NavigateToHalls()
        {
            var hallsPage = _serviceProvider.GetRequiredService<HallsPage>();
            MainFrame.Navigate(hallsPage);
        }
    }
}