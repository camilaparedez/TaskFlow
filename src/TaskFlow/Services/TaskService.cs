using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();

        public void CrearTarea(string titulo, string descripcion, string responsable)
        {
            var nuevaTarea = new TaskItem
            {
                [cite_start]Id = _tasks.Count + 1, [cite: 66]
                [cite_start]Titulo = titulo, [cite: 67]
                [cite_start]Descripcion = descripcion, [cite: 68]
                [cite_start]Responsable = responsable, [cite: 69]
                [cite_start]EstadoInicial = TaskStatus.Pendiente, [cite: 70]
                [cite_start]CreatedAt = DateTime.Now [cite: 75]
            };

            _tasks.Add(nuevaTarea);
            Console.WriteLine("¡Tarea creada con éxito!");
        }
    }
}