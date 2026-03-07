using System.Windows.Controls;
using CinemaManager.DBModels;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for SessionDetailsPage.xaml
    /// </summary>
    public partial class SessionDetailsPage : Page
    {
        private readonly MovieSessionDBModel _session;

        public SessionDetailsPage(MovieSessionDBModel session)
        {
            InitializeComponent();
            _session = session;

            SessionInfo.Text =
                $"Фільм: {_session.Title}\n" +
                $"Жанр: {_session.Genre}\n" +
                $"Рік: {_session.ReleaseYear}\n" +
                $"Початок: {_session.StartTime}\n" +
                $"Тривалість: {_session.DurationMinutes} хв\n" +
                $"Кінець: {_session.StartTime.AddMinutes(_session.DurationMinutes)}";
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
