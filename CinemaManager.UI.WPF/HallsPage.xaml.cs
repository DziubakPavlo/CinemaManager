using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DBModels;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for HallsPage.xaml
    /// </summary>
    public partial class HallsPage : Page
    {
        private readonly IStorageService _storageService;

        public HallsPage()
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
            HallsList.ItemsSource = _storageService.GetAllHalls();
        }

        private void HallsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (HallsList.SelectedItem is CinemaHallDBModel hall)
            {
                NavigationService.Navigate(new HallDetailsPage(hall));
            }
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHallPage());
        }
    }
}
