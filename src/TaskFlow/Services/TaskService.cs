using System;
using System.Collections.Generic;
using System.Linq;
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
            var nuevoId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;

            var nuevaTarea = new TaskItem
            {
                Id = nuevoId,
                Title = titulo,
                Description = descripcion,
                Responsible = responsable,
                Status = Models.TaskStatus.Pendiente,
                CreatedAt = DateTime.Now
            };

            _tasks.Add(nuevaTarea);
            FileManager.SaveTasks(_tasks);
        }
        

        public List<TaskItem> ObtenerTareas()
        {
            return _tasks;
        }
        public List<TaskItem> ObtenerTareasPorEstado(Models.TaskStatus estadoBuscado)
        {
            return _tasks.Where(t => t.Status == estadoBuscado).ToList();
        }
        public TaskItem? ObtenerTareaPorId(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);       
        }
    }
}