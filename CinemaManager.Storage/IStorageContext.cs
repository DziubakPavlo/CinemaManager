using System;
using System.Collections.Generic;
using CinemaManager.DBModels;

namespace CinemaManager.Storage
{
    public interface IStorageContext
    {
        IEnumerable<CinemaHallDBModel> GetHalls();
        CinemaHallDBModel? GetHall(Guid id);

        void AddHall(CinemaHallDBModel hall);

        IEnumerable<MovieSessionDBModel> GetSessions();
        void AddSession(MovieSessionDBModel session);
    }
}