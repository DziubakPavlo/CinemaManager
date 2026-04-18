using CinemaManager.Common.Enums;

namespace CinemaManager.DBModels
{
    //Database model of cinema hall
    public class CinemaHallDBModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public HallType Type { get; set; }

        //DB model initializer
        public CinemaHallDBModel(string name, int seatCount, HallType type) : this(Guid.NewGuid(), name, seatCount, type)
        {
        }

        public CinemaHallDBModel(Guid id, string name, int seatCount, HallType type)
        {
            Id = id;
            Name = name;
            SeatCount = seatCount;
            Type = type;
        }
    }
}
