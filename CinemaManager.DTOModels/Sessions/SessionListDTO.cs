namespace CinemaManager.DTOModels.Sessions
{
    public class SessionListDTO
    {
        public Guid Id { get; }
        public Guid HallId { get; }
        public string Title { get; }
        public Common.Enums.MovieGenre Genre { get; }
        public DateTime StartTime { get; }
        public int DurationMinutes { get; }

        public SessionListDTO(Guid id, Guid hallId, string title, Common.Enums.MovieGenre genre, DateTime startTime, int durationMinutes)
        {
            Id = id;
            HallId = hallId;
            Title = title;
            Genre = genre;
            StartTime = startTime;
            DurationMinutes = durationMinutes;
        }
    }
}
