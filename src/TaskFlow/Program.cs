using TaskFlow.Models;
using TaskFlow.Services;

bool continuar = true;
TaskService taskService = new TaskService();

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
            Console.WriteLine("Funcionalidad Crear tarea aún no implementada.");
            break;

        case "2":
            Console.WriteLine("Funcionalidad Listar tareas aún no implementada.");
            break;

        case "3":
            ActualizarEstado(taskService);
            break;

        case "4":
            Console.WriteLine("Funcionalidad Cambiar responsable aún no implementada.");
            break;

        case "5":
            Console.WriteLine("Funcionalidad Eliminar tarea aún no implementada.");
            break;

        case "6":
            continuar = false;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            break;
    }

    Console.WriteLine();
}

static void ActualizarEstado(TaskService taskService)
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
    TaskStatus nuevoEstado;

    switch (opcionEstado)
    {
        case "1":
            nuevoEstado = TaskStatus.Pendiente;
            break;
        case "2":
            nuevoEstado = TaskStatus.EnProgreso;
            break;
        case "3":
            nuevoEstado = TaskStatus.Completada;
            break;
        default:
            Console.WriteLine("Estado inválido.");
            return;
    }

    bool resultado = taskService.CambiarEstadoTarea(id, nuevoEstado);

    if (resultado)
    {
        Console.WriteLine("Estado actualizado correctamente.");
    }
    else
    {
        Console.WriteLine("No se encontró una tarea con ese ID.");
    }
}