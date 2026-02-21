namespace CinemaManager.DBModels
{
    public class MovieSessionDBModel
    {
        public Guid Id { get; }
        public Guid HallId { get; }
        public string Title { get; }
        public Common.Enums.MovieGenre Genre { get; }
        public int ReleaseYear { get; }
        public DateTime StartTime { get; }
        public int DurationMinutes { get; }

        public MovieSessionDBModel(Guid hallId, string title, Common.Enums.MovieGenre genre, int releaseYear, DateTime startTime, int durationMinutes)
        {
            Id = Guid.NewGuid();
            HallId = hallId;
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            StartTime = startTime;
            DurationMinutes = durationMinutes;
        }
    }
}
