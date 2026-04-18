using CinemaManager.Common.Enums;
using CinemaManager.DBModels;

namespace CinemaManager.Storage
{
    public class InMemoryStorageContext : IStorageContext
    {
        private record class HallRecord(Guid Id, string Name, int SeatCount, HallType Type);
        private record class SessionRecord(Guid Id, Guid HallId, string Title, MovieGenre Genre, int ReleaseYear, DateTime StartTime, int DurationMinutes);

        private static readonly List<HallRecord> _halls = new();
        private static readonly List<SessionRecord> _sessions = new();

        static InMemoryStorageContext()
        {
            var hall1 = new HallRecord(Guid.NewGuid(), "Hall 1", 120, HallType.IMAX);
            var hall2 = new HallRecord(Guid.NewGuid(), "Hall 2", 80, HallType.ThreeD);
            var hall3 = new HallRecord(Guid.NewGuid(), "Hall 3", 100, HallType.TwoD);

            _halls.Add(hall1);
            _halls.Add(hall2);
            _halls.Add(hall3);

            _sessions.Add(new SessionRecord(Guid.NewGuid(), hall1.Id, "Inception", MovieGenre.ScienceFiction, 2010, DateTime.Now.AddHours(1), 148));
            _sessions.Add(new SessionRecord(Guid.NewGuid(), hall2.Id, "The Matrix", MovieGenre.Action, 1999, DateTime.Now.AddHours(2), 136));
            _sessions.Add(new SessionRecord(Guid.NewGuid(), hall3.Id, "The Godfather", MovieGenre.Drama, 1972, DateTime.Now.AddHours(3), 175));
            _sessions.Add(new SessionRecord(Guid.NewGuid(), hall1.Id, "Interstellar", MovieGenre.ScienceFiction, 2014, DateTime.Now.AddHours(4), 169));
            _sessions.Add(new SessionRecord(Guid.NewGuid(), hall2.Id, "Avatar", MovieGenre.ScienceFiction, 2009, DateTime.Now.AddHours(5), 162));
        }

        public IEnumerable<CinemaHallDBModel> GetHalls()
        {
            foreach (var hall in _halls)
            {
                yield return new CinemaHallDBModel(hall.Id, hall.Name, hall.SeatCount, hall.Type);
            }
        }

        public CinemaHallDBModel? GetHall(Guid hallId)
        {
            var hall = _halls.FirstOrDefault(h => h.Id == hallId);
            return hall is null ? null : new CinemaHallDBModel(hall.Id, hall.Name, hall.SeatCount, hall.Type);
        }

        public void AddHall(CinemaHallDBModel hall)
        {
            _halls.Add(new HallRecord(hall.Id, hall.Name, hall.SeatCount, hall.Type));
        }

        public IEnumerable<MovieSessionDBModel> GetSessions()
        {
            return _sessions.Select(s => new MovieSessionDBModel(s.Id, s.HallId, s.Title, s.Genre, s.ReleaseYear, s.StartTime, s.DurationMinutes));
        }

        public void AddSession(MovieSessionDBModel session)
        {
            _sessions.Add(new SessionRecord(session.Id, session.HallId, session.Title, session.Genre, session.ReleaseYear, session.StartTime, session.DurationMinutes));
        }

    }
}
