using CinemaManager.DBModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CinemaManager.Services
{
    public class StorageService : IStorageService
    {
        private ObservableCollection<CinemaHallDBModel> _halls;
        private ObservableCollection<MovieSessionDBModel> _sessions;

        private void LoadData()
        {
            if (_halls != null && _sessions != null)
                return;

            _halls = new ObservableCollection<CinemaHallDBModel>(FakeStorage.Halls);
            _sessions = new ObservableCollection<MovieSessionDBModel>(FakeStorage.Sessions);
        }

        public IEnumerable<CinemaHallDBModel> GetAllHalls()
        {
            LoadData();
            return _halls;
        }

        public IEnumerable<MovieSessionDBModel> GetSessions(string hallName)
        {
            LoadData();
            var hall = GetHallByName(hallName);
            if (hall == null)
                return Enumerable.Empty<MovieSessionDBModel>();

            return _sessions.Where(s => s.HallId == hall.Id);
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
