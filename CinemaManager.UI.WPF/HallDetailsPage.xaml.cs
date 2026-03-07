using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DBModels;
using CinemaManager.ViewModels;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for HallDetailsPage.xaml
    /// </summary>
    public partial class HallDetailsPage : Page
    {
        private readonly IStorageService _storageService;
        private readonly CinemaHallDBModel _hall;
        private readonly CinemaHallViewModel _hallViewModel;

        //Page constructor
        public HallDetailsPage(CinemaHallDBModel hall)
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
            _hall = hall;
            _hallViewModel = new CinemaHallViewModel(hall);

            //Set hall details in the UI
            HallName.Text = _hallViewModel.ToString();
            SessionsList.ItemsSource = _storageService.GetSessions(_hall.Name);

            //Refresh sessions list when page is loaded
            this.Loaded += HallDetailsPage_Loaded;
        }

        //Load sessions for the hall when page is loaded
        private void HallDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            SessionsList.ItemsSource = _storageService.GetSessions(_hall.Name);
        }

        //Handle double-click on a session to navigate to its details page
        private void SessionsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SessionsList.SelectedItem is MovieSessionDBModel session)
            {
                NavigationService.Navigate(new SessionDetailsPage(session));
            }
        }

        //Handle Add button click to navigate to the AddSessionPage
        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSessionPage(_hall));
        }

        //Handle Back button click to navigate back to the previous page
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
