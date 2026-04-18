using CinemaManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Repositories
{
    public interface ISessionRepository
    {
        IEnumerable<MovieSessionDBModel> GetAllSessions();
        void AddSession(MovieSessionDBModel session);
    }
}
