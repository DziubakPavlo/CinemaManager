using CinemaManager.DTOModels.Halls;
using CinemaManager.Common.Enums;

namespace CinemaManager.Services
{
    public interface IHallService
    {
        IEnumerable<HallDetailsDTO> GetAllHalls();
        HallDetailsDTO? GetHall(Guid id);
        void CreateHall(string name, int seatCount, HallType type);
    }
}
