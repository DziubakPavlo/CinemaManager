using CinemaManager.Common.Enums;

namespace CinemaManager.DBModels
{
    //Database model of cinema hall
    public class CinemaHallDBModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public int SeatCount { get; }
        public HallType Type { get; }

        //DB model initializer
        public CinemaHallDBModel(string name, int seatCount, HallType type)
        {
            Id = Guid.NewGuid();
            Name = name;
            SeatCount = seatCount;
            Type = type;
        }
    }
}
