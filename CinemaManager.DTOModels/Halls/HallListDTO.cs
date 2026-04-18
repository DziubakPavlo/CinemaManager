using CinemaManager.Common.Enums;

namespace CinemaManager.DTOModels.Halls
{
    public class HallListDTO
    {
        public Guid Id { get; }
        public string Name { get; }
        public int SeatCount { get; }
        public HallType Type { get; }

        public HallListDTO(Guid id, string name, int seatCount, HallType type)
        {
            Id = id;
            Name = name;
            SeatCount = seatCount;
            Type = type;
        }
    }
}
