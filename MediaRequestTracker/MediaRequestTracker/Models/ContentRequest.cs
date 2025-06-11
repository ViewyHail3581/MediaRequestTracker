using System;

namespace MediaRequestTracker.Models
{
    public class ContentRequest
    {
        public int RequestID { get; set; }
        public string ClientName { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        // Parameterless constructor needed for deserialization
        public ContentRequest() { }

        public ContentRequest(int requestId, string clientName, string platform, string description, DateTime dueDate, string status)
        {
            if (string.IsNullOrWhiteSpace(clientName)) throw new ArgumentException("Client name is required.");
            if (string.IsNullOrWhiteSpace(platform)) throw new ArgumentException("Platform is required.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description is required.");
            if (string.IsNullOrWhiteSpace(status)) throw new ArgumentException("Status is required.");

            RequestID = requestId;
            ClientName = clientName;
            Platform = platform;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }

    }
}

