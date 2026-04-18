using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DTOModels.Halls;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for HallsPage.xaml
    /// </summary>
    public partial class HallsPage : Page
    {
        private readonly IHallService _hallService;
        private readonly IServiceProvider _serviceProvider;

        //Page constructor
        public HallsPage(IHallService hallService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _hallService = hallService;
            _serviceProvider = serviceProvider;

            this.Loaded += (s, e) => LoadHalls();
        }

        //Load halls from the service and bind to the list
        private void LoadHalls()
        {
            HallsList.ItemsSource = _hallService.GetAllHalls();
        }

        //Handle double-click on a hall to navigate to its details page
        private void HallsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (HallsList.SelectedItem is HallDetailsDTO hall)
            {
                var page = _serviceProvider.GetRequiredService<HallDetailsPage>();
                page.SetHall(hall);
                NavigationService.Navigate(page);
            }
        }

        //Handle click on the "Add" button to navigate to the page for adding a new hall
        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var page = _serviceProvider.GetRequiredService<AddHallPage>();
            NavigationService.Navigate(page);
        }
    }
}
