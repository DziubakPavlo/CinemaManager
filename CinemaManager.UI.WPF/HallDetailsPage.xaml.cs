using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DBModels;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for HallDetailsPage.xaml
    /// </summary>
    public partial class HallDetailsPage : Page
    {
        private readonly IStorageService _storageService;
        private readonly CinemaHallDBModel _hall;

        public HallDetailsPage(CinemaHallDBModel hall)
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
            _hall = hall;

            HallName.Text = $"Зал: {_hall.Name} | Місць: {_hall.SeatCount} | Тип: {_hall.Type}";
            SessionsList.ItemsSource = _storageService.GetSessions(_hall.Name);

            this.Loaded += HallDetailsPage_Loaded;
        }

        private void HallDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            SessionsList.ItemsSource = _storageService.GetSessions(_hall.Name);
        }

        private void SessionsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SessionsList.SelectedItem is MovieSessionDBModel session)
            {
                NavigationService.Navigate(new SessionDetailsPage(session));
            }
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSessionPage(_hall));
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
