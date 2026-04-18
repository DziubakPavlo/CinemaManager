using CinemaManager.DBModels;
using CinemaManager.DTOModels.Sessions;
using CinemaManager.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IHallRepository _hallRepository;

        public SessionService(ISessionRepository sessionRepository, IHallRepository hallRepository)
        {
            _sessionRepository = sessionRepository;
            _hallRepository = hallRepository;
        }

        public IEnumerable<SessionDetailsDTO> GetAllSessions()
        {
            return _sessionRepository.GetAllSessions().Select(s => new SessionDetailsDTO(s.Id, s.HallId, s.Title, s.Genre, s.ReleaseYear, s.StartTime, s.DurationMinutes));
        }

        public void CreateSession(Guid hallId, string title, Common.Enums.MovieGenre genre, int releaseYear, DateTime startTime, int durationMinutes)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Session title cannot be empty.");
            if (durationMinutes <= 0) throw new Exception("Duration must be greater than zero.");
            var hall = _hallRepository.GetHallById(hallId);
            if (hall == null) throw new Exception("Hall not found.");
            var session = new MovieSessionDBModel(hallId, title, genre, releaseYear, startTime, durationMinutes);
            _sessionRepository.AddSession(session);
        }
    }
}
