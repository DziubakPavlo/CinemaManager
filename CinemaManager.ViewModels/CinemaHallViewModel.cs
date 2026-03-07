using CinemaManager.Common.Enums;
using CinemaManager.DBModels;

namespace CinemaManager.ViewModels
{
    //ViewModel for cinema hall, used to display hall information in the UI
    public class CinemaHallViewModel
    {
        private readonly CinemaHallDBModel _data;

        public CinemaHallViewModel(CinemaHallDBModel data)
        {
            _data = data;
        }

        public Guid Id => _data.Id;
        public string Name => _data.Name;
        public int SeatCount => _data.SeatCount;
        public HallType Type => _data.Type;

        public override string ToString() => $"Hall: {Name}, Seats: {SeatCount}, Type: {Type}";
    }
}
