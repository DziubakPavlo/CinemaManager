using CinemaManager.Common.Enums;
using CinemaManager.DBModels;

namespace CinemaManager.ViewModels
{
    public class MovieSessionViewModel
    {
        private readonly MovieSessionDBModel _data;

        public MovieSessionViewModel(MovieSessionDBModel data)
        {
            _data = data;
        }

        public Guid Id => _data.Id;
        public Guid HallId => _data.HallId;
        public string Title => _data.Title;
        public MovieGenre Genre => _data.Genre;
        public int ReleaseYear => _data.ReleaseYear;
        public DateTime StartTime => _data.StartTime;
        public int DurationMinutes => _data.DurationMinutes;

        public DateTime EndTime => StartTime.AddMinutes(DurationMinutes);

        public override string ToString() => $"{Title} ({Genre}, {ReleaseYear}) | Start: {StartTime:HH:mm}, End: {EndTime:HH:mm} ";
    }
}
