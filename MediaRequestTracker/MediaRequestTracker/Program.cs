using System;
using MediaRequestTracker.Data;
using MediaRequestTracker.Services;

namespace MediaRequestTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Media Request Tracker";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Media Request Tracker!");
            Console.ResetColor();

            var requestManager = new RequestManager();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        requestManager.AddRequest();
                        break;
                    case "2":
                        requestManager.ViewRequests();
                        break;
                    case "3":
                        requestManager.UpdateRequestStatus();
                        break;
                    case "4":
                        requestManager.DeleteRequest();
                        break;
                    case "5":
                        FileHandler.SaveToFile(requestManager.GetRequests());
                        break;
                    case "6":
                        var loadedRequests = FileHandler.LoadFromFile();
                        requestManager.SetRequests(loadedRequests);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n=== Media Request Tracker ===");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Requests");
            Console.WriteLine("3. Update Request Status");
            Console.WriteLine("4. Delete Request");
            Console.WriteLine("5. Save Requests to File");
            Console.WriteLine("6. Load Requests from File");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
        }
    }
}
