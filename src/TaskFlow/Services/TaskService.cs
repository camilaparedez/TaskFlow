using System;
using System.Collections.Generic;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services
{
    public class TaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();

        public TaskService()
        {
            _tasks = FileManager.LoadTasks();
        }

        public void CrearTarea(string titulo, string descripcion, string responsable)
        {
            var nuevaTarea = new TaskItem
            {
                Id = _tasks.Count + 1,
                Title = titulo,
                Description = descripcion,
                Responsible = responsable,
                Status = Models.TaskStatus.Pendiente,
                CreatedAt = DateTime.Now
            };

            _tasks.Add(nuevaTarea);
            FileManager.SaveTasks(_tasks);
        }

        public bool CambiarEstadoTarea(int id, TaskStatus nuevoEstado)
        {
            var tarea = _tasks.Find(t => t.Id == id);

            if (tarea == null)
            {
                return false;
            }

            tarea.Status = nuevoEstado;
            tarea.UpdatedAt = DateTime.Now;

            FileManager.SaveTasks(_tasks);

            return true;
        }
    }
}