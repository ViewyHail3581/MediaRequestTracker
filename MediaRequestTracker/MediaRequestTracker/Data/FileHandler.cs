using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MediaRequestTracker.Models;

namespace MediaRequestTracker.Data
{
    public static class FileHandler
    {
        private static readonly string filePath = "data/requests.json";

        public static void SaveToFile(List<ContentRequest> requests)
        {
            try
            {
                Directory.CreateDirectory("data"); // Ensure folder exists

                var json = JsonSerializer.Serialize(requests, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
                Console.WriteLine("✅ Requests saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving to file: {ex.Message}");
            }
        }

        public static List<ContentRequest> LoadFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<ContentRequest>(); // Return empty list if file doesn't exist
                }

                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<ContentRequest>>(json) ?? new List<ContentRequest>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading from file: {ex.Message}");
                return new List<ContentRequest>();
            }
        }
    }
}
