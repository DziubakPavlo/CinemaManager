using System.Windows.Controls;
using CinemaManager.Services;
using CinemaManager.Common.Enums;
using System.Windows;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for AddHallPage.xaml
    /// </summary>
    public partial class AddHallPage : Page
    {
        private readonly IHallService _hallService;

        //Page constructor
        public AddHallPage(IHallService hallService)
        {
            InitializeComponent();
            _hallService = hallService;

            HallTypeBox.ItemsSource = Enum.GetValues(typeof(HallType));
        }

        //Save button click handler
        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Get hall details from input fields
            string name = HallNameBox.Text;

            if (!int.TryParse(SeatCountBox.Text, out int seats))
            {
                MessageBox.Show("Please enter a valid number of seats.");
                return;
            }

            if (HallTypeBox.SelectedItem is not HallType type)
            {
                MessageBox.Show("Please select a hall type.");
                return;
            }

            //Create new hall through the service and handle any exceptions
            try
            {
                _hallService.CreateHall(name, seats, type);

                MessageBox.Show("Hall created successfully!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Back button click handler
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
