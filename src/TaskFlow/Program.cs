using System;
using TaskFlow.Services;

namespace TaskFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== TaskFlow - Gestión de Tareas ===");
                Console.WriteLine("1. Crear tarea");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- Nueva Tarea ---");
                        Console.Write("Título: ");
                        string tit = Console.ReadLine();
                        Console.Write("Descripción: ");
                        string desc = Console.ReadLine();
                        Console.Write("Responsable: ");
                        string resp = Console.ReadLine();

                        taskService.CrearTarea(tit, desc, resp);
                        
                        Console.WriteLine("\nPresione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;

                    case "6":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}