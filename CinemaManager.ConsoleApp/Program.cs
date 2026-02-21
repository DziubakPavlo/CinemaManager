using CinemaManager.Common.Enums;
using CinemaManager.DBModels;
using CinemaManager.Services;
using CinemaManager.ViewModels;

namespace CinemaManager.ConsoleApp
{
    class Program
    {
        private static IStorageService _storageService;
        static void Main()
        {
            Console.WriteLine("Welcome to the Cinema Manager!");
            _storageService = new StorageService();
            while (true)
            {
                Console.WriteLine("\n1. Show cinema halls");
                Console.WriteLine("2. Show movie sessions");
                Console.WriteLine("3. Add a new cinema hall");
                Console.WriteLine("4. Add a new movie session");
                Console.WriteLine("0. Exit\n");
                Console.Write("Please select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowHalls();
                        break;
                    case "2":
                        ShowSessions();
                        break;
                    case "3":
                        AddHall();
                        break;
                    case "4":
                        AddSession();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private static void ShowHalls()
        {
            foreach (var hall in _storageService.GetAllHalls())
            {
                var hallViewModel = new CinemaHallViewModel(hall);
                Console.WriteLine(hallViewModel);
            }
        }

        private static void ShowSessions()
        {
            Console.Write("Enter hall name to show sessions: ");
            string hallName = Console.ReadLine();

            var sessions = _storageService.GetSessions(hallName);

            if (!sessions.Any())
            {
                Console.WriteLine("Sessions not found");
                return;
            }

            foreach (var session in sessions)
            {
                var sessionViewModel = new MovieSessionViewModel(session);
                Console.WriteLine(sessionViewModel);
            }
        }

        static void AddHall()
        {
            Console.WriteLine("Hall Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Seat Count: ");
            int seatCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Hall type (0 - 2D, 1 - 3D, 2 - IMAX): ");
            HallType type = (HallType)int.Parse(Console.ReadLine());

            var hall = new CinemaHallDBModel(name, seatCount, type);
            _storageService.AddHall(hall);

            Console.WriteLine("Hall added successfully.");
        }

        static void AddSession()
        {
            Console.WriteLine("Hall Name: ");
            string hallName = Console.ReadLine();

            var hall = _storageService.GetHallByName(hallName);
            if (hall == null)
            {
                Console.WriteLine("Hall not found");
                return;
            }

            Console.WriteLine("Movie Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Genre: ");
            Console.WriteLine("0 - Animation");
            Console.WriteLine("1 - Horror");
            Console.WriteLine("2 - Comedy");
            Console.WriteLine("3 - Action");
            Console.WriteLine("4 - Science Fiction");
            Console.WriteLine("5 - Drama");
            Console.WriteLine("6 - Fantasy");
            Console.WriteLine("7 - Thriller");
            Console.WriteLine("8 - Romance");
            Console.WriteLine("9 - Documentary");
            MovieGenre genre = (MovieGenre)int.Parse(Console.ReadLine());

            Console.WriteLine("Release Year: ");
            int releaseYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Start Time (yyyy-MM-dd HH:mm): ");
            DateTime startTime = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);

            Console.WriteLine("Duration (minutes): ");
            int durationMinutes = int.Parse(Console.ReadLine());

            var session = new MovieSessionDBModel(hall.Id, title, genre, releaseYear, startTime, durationMinutes);
            _storageService.AddSession(session);

            Console.WriteLine("Session added successfully.");
        }
    }
}