using System.Windows.Controls;
using CinemaManager.DBModels;
using CinemaManager.ViewModels;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for SessionDetailsPage.xaml
    /// </summary>
    public partial class SessionDetailsPage : Page
    {
        private readonly MovieSessionDBModel _session;
        private readonly MovieSessionViewModel _viewModel;

        //Page constructor
        public SessionDetailsPage(MovieSessionDBModel session)
        {
            InitializeComponent();
            _session = session;
            _viewModel = new MovieSessionViewModel(session);

            //Output session details in the UI
            SessionInfo.Text = _viewModel.ToString();
        }

        //Handle Back button click to navigate back to the previous page
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
