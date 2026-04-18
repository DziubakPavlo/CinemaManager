using System.Windows.Controls;
using CinemaManager.Services;
using CinemaManager.Common.Enums;
using CinemaManager.DTOModels.Halls;
using System.Windows;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for AddSessionPage.xaml
    /// </summary>
    public partial class AddSessionPage : Page
    {
        private readonly ISessionService _sessionService;

        private HallDetailsDTO _hall = null!;

        //Page constructor
        public AddSessionPage(ISessionService sessionService)
        {
            InitializeComponent();
            
            _sessionService = sessionService;

            GenreBox.ItemsSource = Enum.GetValues(typeof(MovieGenre));
        }

        public void SetHall(HallDetailsDTO hall)
        {
            _hall = hall;
        }

        //Save button click event handler
        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Validate hall information
            if (_hall == null)
            {
                MessageBox.Show("Hall information is missing.");
                return;
            }

            //Get input values
            string title = MovieTitleBox.Text;

            if (GenreBox.SelectedItem is not MovieGenre genre)
            {
                MessageBox.Show("Please select a movie genre.");
                return;
            }

            if (!int.TryParse(YearBox.Text, out int year))
            {
                MessageBox.Show("Please enter a valid release year.");
                return;
            }

            if (!DateTime.TryParse(StartBox.Text, out DateTime start))
            {
                MessageBox.Show("Please enter a valid start time.");
                return;
            }

            if (!int.TryParse(DurationBox.Text, out int duration))
            {
                MessageBox.Show("Please enter a valid duration in minutes.");
                return;
            }

            //Create new session and save to storage
            try
            {
                _sessionService.CreateSession(_hall.Id, title, genre, year, start, duration);

                MessageBox.Show("Session added successfully.");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Back button click event handler
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
