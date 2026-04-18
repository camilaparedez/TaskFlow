using TaskFlow.Services;

TaskService servicio = new TaskService();


using ModeloTaskStatus = TaskFlow.Models.TaskStatus;

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
            Console.WriteLine("\n--- CREAR NUEVA TAREA ---");
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? "";
            Console.Write("Descripción: ");
            string desc = Console.ReadLine() ?? "";
            Console.Write("Responsable: ");
            string resp = Console.ReadLine() ?? "";

            taskService.CrearTarea(titulo, desc, resp);
            Console.WriteLine("¡Tarea creada y guardada en el JSON!");
            break;

        case "2":
            var listaTareas = taskService.ObtenerTareas();
            Console.WriteLine("===LISTADO DE TAREAS===");
            if (listaTareas.Count == 0)
            {
              Console.WriteLine("No hay tareas registradas.");
            }
            else
            {
              foreach (var tarea in listaTareas)
              {
                Console.WriteLine($"[{tarea.Id}] {tarea.Title} | Resp: {tarea.Responsible} | Estado: {tarea.Status}");
              }
            }
            break;

        case "3":
            ActualizarEstado(taskService);
            break;

        case "4":
            CambiarResponsable(taskService);
            break;

        case "5":
            EliminarTarea(taskService);
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
    ModeloTaskStatus nuevoEstado;

    switch (opcionEstado)
    {
        case "1":
            nuevoEstado = ModeloTaskStatus.Pendiente;
            break;
        case "2":
            nuevoEstado = ModeloTaskStatus.EnProgreso;
            break;
        case "3":
            nuevoEstado = ModeloTaskStatus.Completada;
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

static void CambiarResponsable(TaskService taskService)
{
    Console.Write("Ingrese el ID de la tarea: ");
    string? inputId = Console.ReadLine();

    if (!int.TryParse(inputId, out int id))
    {
        Console.WriteLine("El ID debe ser numérico.");
        return;
    }

    Console.Write("Ingrese el nuevo responsable: ");
    string? nuevoResponsable = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nuevoResponsable))
    {
        Console.WriteLine("El responsable no puede estar vacío.");
        return;
    }

    bool resultado = taskService.CambiarResponsable(id, nuevoResponsable);

    if (resultado)
    {
        Console.WriteLine("Responsable actualizado correctamente.");
    }
    else
    {
        Console.WriteLine("No se encontró una tarea con ese ID.");
    }
}

static void EliminarTarea(TaskService taskService)
{
    Console.Write("Ingrese el ID de la tarea a eliminar: ");
    string? inputId = Console.ReadLine();

    if (!int.TryParse(inputId, out int id))
    {
        Console.WriteLine("El ID debe ser numérico.");
        return;
    }

    bool resultado = taskService.EliminarTarea(id);

    if (resultado)
    {
        Console.WriteLine("Tarea eliminada correctamente.");
    }
    else
    {
        Console.WriteLine("No se encontró una tarea con ese ID.");
    }
}

