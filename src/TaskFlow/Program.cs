// Ejemplo de Opción 1
case "1":
    Console.Clear();
    Console.WriteLine("--- Crear Nueva Tarea ---");
    
    Console.Write("Título: ");
    string titulo = Console.ReadLine();
    
    Console.Write("Descripción: ");
    string descripcion = Console.ReadLine();
    
    Console.Write("Responsable: ");
    string responsable = Console.ReadLine();

    // Llamamos al servicio para crearla
    taskService.CrearTarea(titulo, descripcion, responsable);
    
    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
    Console.ReadKey();
    break;