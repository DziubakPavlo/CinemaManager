using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using CinemaManager.Services;
using CinemaManager.DBModels;
using CinemaManager.Common.Enums;

namespace CinemaManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for AddHallPage.xaml
    /// </summary>
    public partial class AddHallPage : Page
    {
        private readonly IStorageService _storageService;
        public AddHallPage()
        {
            InitializeComponent();
            _storageService = App.ServiceProvider.GetService<IStorageService>();
        }

        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string name = HallNameBox.Text;
            int seats = int.Parse(SeatCountBox.Text);
            HallType type = (HallType)HallTypeBox.SelectedIndex;

            var hall = new CinemaHallDBModel(name, seats, type);
            _storageService.AddHall(hall);

            NavigationService.GoBack();
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
