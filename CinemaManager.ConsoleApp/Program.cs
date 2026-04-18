using CinemaManager.Common.Enums;
using CinemaManager.Repositories;
using CinemaManager.Services;
using CinemaManager.Storage;

namespace CinemaManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IStorageContext storage = new InMemoryStorageContext();

            IHallRepository hallRepository = new HallRepository(storage);
            ISessionRepository sessionRepository = new SessionRepository(storage);

            IHallService hallService = new HallService(hallRepository);
            ISessionService sessionService = new SessionService(sessionRepository, hallRepository);

            while (true)
            {
                Console.WriteLine("\n1 - Show halls");
                Console.WriteLine("2 - Create hall");
                Console.WriteLine("3 - Show sessions");
                Console.WriteLine("4 - Create session");
                Console.WriteLine("0 - Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowHalls(hallService);
                        break;

                    case "2":
                        CreateHall(hallService);
                        break;

                    case "3":
                        ShowSessions(sessionService);
                        break;

                    case "4":
                        CreateSession(sessionService);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void ShowHalls(IHallService hallService)
        {
            var halls = hallService.GetAllHalls();

            foreach (var hall in halls)
            {
                Console.WriteLine($"{hall.Id} | {hall.Name} | Seats: {hall.SeatCount}");
            }
        }

        static void CreateHall(IHallService hallService)
        {
            Console.Write("Enter hall name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Console.Write("Enter seat count: ");
            if (!int.TryParse(Console.ReadLine(), out int seats))
            {
                Console.WriteLine("Invalid number");
                return;
            }

            Console.WriteLine("Select hall type:");
            foreach (var t in Enum.GetValues(typeof(HallType)))
            {
                Console.WriteLine($"{(int)t} - {t}");
            }

            if (!int.TryParse(Console.ReadLine(), out int typeInput) ||
                !Enum.IsDefined(typeof(HallType), typeInput))
            {
                Console.WriteLine("Invalid type");
                return;
            }

            var type = (HallType)typeInput;

            try
            {
                hallService.CreateHall(name, seats, type);
                Console.WriteLine("Hall created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowSessions(ISessionService sessionService)
        {
            var sessions = sessionService.GetAllSessions();

            foreach (var s in sessions)
            {
                Console.WriteLine($"{s.Id} | Movie: {s.Title} | HallId: {s.HallId} | {s.StartTime}");
            }
        }

        static void CreateSession(ISessionService sessionService)
        {
            Console.Write("Enter hall Id: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid hallId))
            {
                Console.WriteLine("Invalid Guid");
                return;
            }

            Console.Write("Enter movie title: ");
            var title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty");
                return;
            }

            Console.WriteLine("Select genre:");
            foreach (var g in Enum.GetValues(typeof(MovieGenre)))
            {
                Console.WriteLine($"{(int)g} - {g}");
            }

            if (!int.TryParse(Console.ReadLine(), out int genreInput) ||
                !Enum.IsDefined(typeof(MovieGenre), genreInput))
            {
                Console.WriteLine("Invalid genre");
                return;
            }

            var genre = (MovieGenre)genreInput;

            Console.Write("Enter release year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year");
                return;
            }

            Console.Write("Enter duration (minutes): ");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid duration");
                return;
            }

            Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startTime))
            {
                Console.WriteLine("Invalid date");
                return;
            }

            try
            {
                sessionService.CreateSession(
                    hallId,
                    title,
                    genre,
                    year,
                    startTime,
                    duration);

                Console.WriteLine("Session created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}