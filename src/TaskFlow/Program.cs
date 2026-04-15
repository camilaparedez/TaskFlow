using TaskFlow.Services;

bool continuar = true;

while (continuar)
{
    Console.WriteLine("=== TASKFLOW ===");
    Console.WriteLine("1. Crear tarea");
    Console.WriteLine("2. Listar tareas");
    Console.WriteLine("3. Actualizar estado");
    Console.WriteLine("4. Cambiar responsable");
    Console.WriteLine("5. Eliminar tarea");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // lógica crear tarea
            break;

        case "2":
            // lógica listar tareas
            break;

        case "3":
            ActualizarEstado();
            break;

        case "4":
            // lógica cambiar responsable
            break;

        case "5":
            // lógica eliminar tarea
            break;

        case "6":
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            break;
    }

    Console.WriteLine();
}

static void ActualizarEstado()
{
    Console.Write("Ingrese el ID de la tarea: ");
    string? inputId = Console.ReadLine();

    if (!int.TryParse(inputId, out int id))
    {
        Console.WriteLine("El ID debe ser numérico.");
        return;
    }

    Console.WriteLine("Seleccione el nuevo estado:");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En progreso");
    Console.WriteLine("3. Completada");
    Console.Write("Opción: ");

    string? opcionEstado = Console.ReadLine();

    switch (opcionEstado)
    {
        case "1":
            Console.WriteLine($"Se solicitó cambiar la tarea {id} a Pendiente.");
            break;

        case "2":
            Console.WriteLine($"Se solicitó cambiar la tarea {id} a En progreso.");
            break;

        case "3":
            Console.WriteLine($"Se solicitó cambiar la tarea {id} a Completada.");
            break;

        default:
            Console.WriteLine("Estado inválido.");
            break;
    }
}