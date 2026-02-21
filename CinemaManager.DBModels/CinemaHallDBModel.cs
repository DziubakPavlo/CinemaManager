using CinemaManager.Common.Enums;

namespace CinemaManager.DBModels
{
    public class CinemaHallDBModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public int SeatCount { get; }
        public HallType Type { get; }

        public CinemaHallDBModel(string name, int seatCount, HallType type)
        {
            Id = Guid.NewGuid();
            Name = name;
            SeatCount = seatCount;
            Type = type;
        }
    }
}
