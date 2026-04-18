using CinemaManager.DBModels;

namespace CinemaManager.Repositories
{
    public interface IHallRepository
    {
        IEnumerable<CinemaHallDBModel> GetAllHalls();
        CinemaHallDBModel? GetHallById(Guid id);
        void AddHall(CinemaHallDBModel hall);
    }
}
