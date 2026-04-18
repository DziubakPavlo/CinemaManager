using CinemaManager.DBModels;
using CinemaManager.Storage;

namespace CinemaManager.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly IStorageContext _storage;

        public HallRepository(IStorageContext storage)
        {
            _storage = storage;
        }

        public IEnumerable<CinemaHallDBModel> GetAllHalls()
        {
            return _storage.GetHalls();
        }

        public CinemaHallDBModel? GetHallById(Guid id)
        {
            return _storage.GetHall(id);
        }

        public void AddHall(CinemaHallDBModel hall)
        {
            _storage.AddHall(hall);
        }
    }
}
