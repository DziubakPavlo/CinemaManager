using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DBModels;
using CinemaManager.Common.Enums;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for AddSessionPage.xaml
    /// </summary>
    public partial class AddSessionPage : Page
    {
        private readonly IStorageService _storageService;
        private readonly CinemaHallDBModel _hall;

        //Page constructor
        public AddSessionPage(CinemaHallDBModel hall)
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
            _hall = hall;
        }

        //Save button click event handler
        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Get input values
            string title = MovieTitleBox.Text;
            MovieGenre genre = (MovieGenre)GenreBox.SelectedIndex;
            int year = int.Parse(YearBox.Text);
            DateTime start = DateTime.Parse(StartBox.Text);
            int duration = int.Parse(DurationBox.Text);

            //Create new session and save to storage
            var session = new MovieSessionDBModel(_hall.Id, title, genre, year, start, duration);
            _storageService.AddSession(session);

            NavigationService.GoBack();
        }

        //Back button click event handler
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
