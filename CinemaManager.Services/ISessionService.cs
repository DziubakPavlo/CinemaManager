using CinemaManager.Common.Enums;
using CinemaManager.DTOModels.Sessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Services
{
    public interface ISessionService
    {
        IEnumerable<SessionDetailsDTO> GetAllSessions();
        void CreateSession(Guid hallId, string title, MovieGenre genre, int releaseYear, DateTime startTime, int duration);
    }
}
