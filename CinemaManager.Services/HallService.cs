using CinemaManager.Repositories;
using CinemaManager.DTOModels.Halls;
using CinemaManager.DBModels;

namespace CinemaManager.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _repository;

        public HallService(IHallRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<HallDetailsDTO> GetAllHalls()
        {
            return _repository.GetAllHalls().Select(h => new HallDetailsDTO(h.Id, h.Name, h.SeatCount, h.Type));
        }

        public HallDetailsDTO? GetHall(Guid id)
        {
            var hall = _repository.GetHallById(id);

            if (hall == null) return null;

            return new HallDetailsDTO(hall.Id, hall.Name, hall.SeatCount, hall.Type);
        }

        public void CreateHall(string name, int seatCount, Common.Enums.HallType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Hall name cannot be empty.");

            if (seatCount <= 0) throw new Exception("Seat count must be greater than zero.");

            var hall = new CinemaHallDBModel(name, seatCount, type);

            _repository.AddHall(hall);
        }
    }
}
