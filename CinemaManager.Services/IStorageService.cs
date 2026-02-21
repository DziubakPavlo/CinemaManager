using CinemaManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManager.Services
{
    public interface IStorageService
    {
        IEnumerable<CinemaHallDBModel> GetAllHalls();
        IEnumerable<MovieSessionDBModel> GetSessions(string hallName);

        void AddHall(CinemaHallDBModel hall);
        void AddSession(MovieSessionDBModel session);

        CinemaHallDBModel GetHallByName(string hallName);
    }
}
