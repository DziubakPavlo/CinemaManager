using System.Windows;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Main window constructor
        public MainWindow()
        {
            InitializeComponent();
            //Navigate to the HallsPage on startup
            MainFrame.Navigate(new HallsPage());
        }
    }
}