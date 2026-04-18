using CinemaManager.DBModels;
using CinemaManager.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IStorageContext _storage;

        public SessionRepository(IStorageContext storage)
        {
            _storage = storage;
        }

        public IEnumerable<MovieSessionDBModel> GetAllSessions()
        {
            return _storage.GetSessions();
        }

        public void AddSession(MovieSessionDBModel session)
        {
            _storage.AddSession(session);
        }
    }
}
