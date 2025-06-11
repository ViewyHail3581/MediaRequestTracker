using System;
using System.Collections.Generic;
using System.Linq;
using MediaRequestTracker.Models;

namespace MediaRequestTracker.Services
{
    class RequestManager
    {
        private List<ContentRequest> requests;
        private int nextRequestId;

        public RequestManager()
        {
            nextRequestId = 1;
            requests = new List<ContentRequest>();
        }

        public void AddRequest()
        {
            Console.WriteLine("\n--- Add New Content Request ---");

            string clientName = PromptNonEmptyInput("Client Name: ");
            string platform = PromptNonEmptyInput("Platform (e.g., Social Media, Print, Radio): ");
            string description = PromptNonEmptyInput("Description: ");
            DateTime dueDate = PromptValidDate("Due Date (yyyy-mm-dd): ");
            string status = PromptNonEmptyInput("Status (e.g., Pending, In Progress, Completed): ");

            ContentRequest newRequest = new ContentRequest(
                nextRequestId,
                clientName,
                platform,
                description,
                dueDate,
                status
            );

            requests.Add(newRequest);
            Console.WriteLine($"✅ Request #{nextRequestId} added successfully.\n");
            nextRequestId++;
        }

        public void ViewRequests()
        {
            Console.WriteLine("\n--- All Content Requests ---");

            if (requests.Count == 0)
            {
                Console.WriteLine("No requests found.\n");
                return;
            }

            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.RequestID}");
                Console.WriteLine($"Client Name: {request.ClientName}");
                Console.WriteLine($"Platform: {request.Platform}");
                Console.WriteLine($"Description: {request.Description}");
                Console.WriteLine($"Due Date: {request.DueDate:yyyy-MM-dd}");
                Console.WriteLine($"Status: {request.Status}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public void UpdateRequestStatus()
        {
            Console.WriteLine("\n--- Update Request Status ---");

            Console.Write("Enter the Request ID to update: ");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int requestId))
            {
                Console.WriteLine("❌ Invalid ID. Please enter a number.\n");
                return;
            }

            ContentRequest request = FindRequestById(requestId);
            if (request == null)
            {
                Console.WriteLine($"❌ No request found with ID {requestId}.\n");
                return;
            }

            Console.WriteLine($"Current Status: {request.Status}");
            string newStatus = PromptNonEmptyInput("Enter new status (e.g., Pending, In Progress, Completed): ");
            request.Status = newStatus;

            Console.WriteLine($"✅ Request #{requestId} status updated to \"{newStatus}\".\n");
        }

        public void DeleteRequest()
        {
            Console.WriteLine("\n--- Delete Content Request ---");

            Console.Write("Enter the Request ID to delete: ");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int requestId))
            {
                Console.WriteLine("❌ Invalid ID. Please enter a number.\n");
                return;
            }

            ContentRequest request = FindRequestById(requestId);
            if (request == null)
            {
                Console.WriteLine($"❌ No request found with ID {requestId}.\n");
                return;
            }

            requests.Remove(request);
            Console.WriteLine($"✅ Request #{requestId} has been deleted.\n");
        }

        public List<ContentRequest> GetRequests()
        {
            return requests;
        }

        public void SetRequests(List<ContentRequest> loadedRequests)
        {
            requests = loadedRequests ?? new List<ContentRequest>();
            nextRequestId = requests.Count > 0 ? requests.Max(r => r.RequestID) + 1 : 1;
        }

        private ContentRequest FindRequestById(int requestId)
        {
            return requests.FirstOrDefault(r => r.RequestID == requestId);
        }

        private string PromptNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("❌ Input cannot be empty.");
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        private DateTime PromptValidDate(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out date))
                    break;
                else
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
            }
            return date;
        }
    }
}
