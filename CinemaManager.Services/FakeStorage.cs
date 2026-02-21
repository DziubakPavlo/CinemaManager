using CinemaManager.Common.Enums;
using CinemaManager.DBModels;

namespace CinemaManager.Services
{
    internal static class FakeStorage
    {
        private static readonly List<CinemaHallDBModel> _halls;
        private static readonly List<MovieSessionDBModel> _sessions;

        internal static IEnumerable<CinemaHallDBModel> Halls
        {
            get { return _halls.ToList(); } 
        }

        internal static IEnumerable<MovieSessionDBModel> Sessions
        {
            get { return _sessions.ToList(); }
        }

        static FakeStorage()
        {
            var hall1 = new CinemaHallDBModel("Hall 1", 120, HallType.IMAX);
            var hall2 = new CinemaHallDBModel("Hall 2", 80, HallType.ThreeD);
            var hall3 = new CinemaHallDBModel("Hall 3", 100, HallType.TwoD);

            _halls = new List<CinemaHallDBModel> { hall1, hall2, hall3 };

            _sessions = new List<MovieSessionDBModel>
            {
                new MovieSessionDBModel(hall1.Id, "Inception", MovieGenre.ScienceFiction, 2010, DateTime.Now.AddHours(1), 148),
                new MovieSessionDBModel(hall2.Id, "The Matrix", MovieGenre.Action, 1999, DateTime.Now.AddHours(2), 136),
                new MovieSessionDBModel(hall3.Id, "The Godfather", MovieGenre.Drama, 1972, DateTime.Now.AddHours(3), 175),
                new MovieSessionDBModel(hall1.Id, "Interstellar", MovieGenre.ScienceFiction, 2014, DateTime.Now.AddHours(4), 169),
                new MovieSessionDBModel(hall2.Id, "Avatar", MovieGenre.ScienceFiction, 2009, DateTime.Now.AddHours(5), 162)
            };
        }
    }
}
