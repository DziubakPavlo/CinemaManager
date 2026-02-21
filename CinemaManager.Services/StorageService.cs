using CinemaManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Services
{
    public class StorageService : IStorageService
    {
        private List<CinemaHallDBModel> _halls;
        private List<MovieSessionDBModel> _sessions;

        private void LoadData()
        {
            if (_halls != null && _sessions != null)
                return;

            _halls = FakeStorage.Halls.ToList();
            _sessions = FakeStorage.Sessions.ToList();
        }

        public IEnumerable<CinemaHallDBModel> GetAllHalls()
        {
            LoadData();
            return _halls.ToList();
        }

        public IEnumerable<MovieSessionDBModel> GetSessions(string hallName)
        {
            LoadData();
            var hall = GetHallByName(hallName);
            if (hall == null)
                return Enumerable.Empty<MovieSessionDBModel>();

            return _sessions.Where(s => s.HallId == hall.Id).ToList();
        }

        public void AddHall(CinemaHallDBModel hall)
        {
            LoadData();
            _halls.Add(hall);
        }

        public void AddSession(MovieSessionDBModel session)
        {
            LoadData();
            _sessions.Add(session);
        }

        public CinemaHallDBModel GetHallByName(string hallName)
        {
            LoadData();
            return _halls.FirstOrDefault(h => h.Name.Equals(hallName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
