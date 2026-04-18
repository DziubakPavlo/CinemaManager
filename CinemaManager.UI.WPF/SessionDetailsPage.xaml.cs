using System.Windows.Controls;
using CinemaManager.DTOModels.Sessions;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for SessionDetailsPage.xaml
    /// </summary>
    public partial class SessionDetailsPage : Page
    {
        private SessionDetailsDTO _session = null!;

        //Page constructor
        public SessionDetailsPage()
        {
            InitializeComponent();
        }

        public void SetSession(SessionDetailsDTO session)
        {
            _session = session;

            SessionInfo.Text =
                $"Назва: {session.Title}\n" +
                $"Жанр: {session.Genre}\n" +
                $"Рік: {session.ReleaseYear}\n" +
                $"Початок: {session.StartTime}\n" +
                $"Тривалість: {session.DurationMinutes} хв";
        }

        //Handle Back button click to navigate back to the previous page
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
