using System.Text.Json;
using TaskFlow.Models;

namespace TaskFlow.Utils
{
    public static class FileManager
    {
        private static readonly string DirectoryPath = "data";
        private static readonly string FilePath = Path.Combine(DirectoryPath, "tasks.json");

        public static void SaveTasks(List<TaskItem> tasks)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(tasks, options);
                
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crítico de persistencia: {ex.Message}");
            }
        }

        public static List<TaskItem> LoadTasks()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return new List<TaskItem>();
                }

                string jsonString = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(jsonString) ?? new List<TaskItem>();
            }
            catch (Exception ex)
            {
                return new List<TaskItem>();
            }
        }
    }
}