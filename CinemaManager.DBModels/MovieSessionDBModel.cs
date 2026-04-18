namespace CinemaManager.DBModels
{
    // Database model for movie session
    public class MovieSessionDBModel
    {
        public Guid Id { get; }
        public Guid HallId { get; }
        public string Title { get; }
        public Common.Enums.MovieGenre Genre { get; }
        public int ReleaseYear { get; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; }

        //DB model initializer
        public MovieSessionDBModel(Guid hallId, string title, Common.Enums.MovieGenre genre, int releaseYear, DateTime startTime, int durationMinutes) : this(Guid.NewGuid(), hallId, title, genre, releaseYear, startTime, durationMinutes)
        {
        }

        public MovieSessionDBModel(Guid id, Guid hallId, string title, Common.Enums.MovieGenre genre, int releaseYear, DateTime startTime, int durationMinutes)
        {
            Id = id;
            HallId = hallId;
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            StartTime = startTime;
            DurationMinutes = durationMinutes;
        }
    }
}
