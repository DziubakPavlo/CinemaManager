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

        //Page constructor
        public HallsPage()
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
            HallsList.ItemsSource = _storageService.GetAllHalls();
        }

        //Handle double-click on a hall to navigate to its details page
        private void HallsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (HallsList.SelectedItem is CinemaHallDBModel hall)
            {
                NavigationService.Navigate(new HallDetailsPage(hall));
            }
        }

        //Handle click on the "Add" button to navigate to the page for adding a new hall
        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHallPage());
        }
    }
}
