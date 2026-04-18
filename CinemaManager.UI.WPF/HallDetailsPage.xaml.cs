using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DTOModels.Halls;
using CinemaManager.DTOModels.Sessions;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for HallDetailsPage.xaml
    /// </summary>
    public partial class HallDetailsPage : Page
    {
        private readonly ISessionService _sessionService;
        private readonly IServiceProvider _serviceProvider;

        private HallDetailsDTO _hall = null!;

        //Page constructor
        public HallDetailsPage(ISessionService sessionService, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _sessionService = sessionService;
            _serviceProvider = serviceProvider;
        }

        public void SetHall(HallDetailsDTO hall)
        {
            _hall = hall;

            HallName.Text = $"{hall.Name} ({hall.Type}) - {hall.SeatCount} місць";

            this.Loaded += (s, e) => LoadSessions();
        }

        private void LoadSessions()
        {
            var sessions = _sessionService.GetAllSessions()
                .Where(s => s.HallId == _hall.Id);

            SessionsList.ItemsSource = sessions;
        }

        //Handle double-click on a session to navigate to its details page
        private void SessionsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SessionsList.SelectedItem is SessionDetailsDTO session)
            {
                var page = _serviceProvider.GetRequiredService<SessionDetailsPage>();
                page.SetSession(session);
                NavigationService.Navigate(page);
            }
        }

        //Handle Add button click to navigate to the AddSessionPage
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var page = _serviceProvider.GetRequiredService<AddSessionPage>();
            page.SetHall(_hall);
            NavigationService.Navigate(page);
        }

        //Handle Back button click to navigate back to the previous page
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
