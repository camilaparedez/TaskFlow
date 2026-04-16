using TaskFlow.Services;
TaskService servicio = new TaskService();
var listaTareas = servicio.ObtenerTareas();
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
