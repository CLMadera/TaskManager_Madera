using Domain.Models;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IGenericRepository<TaskItem> _repository;

        public TaskItemService(IGenericRepository<TaskItem> repository)
        {
            _repository = repository;
        }

        public TaskItem? Create(string title, string description, TaskItemPriority priority, int? projectId,
            User? assignedTo, DateTime? dueDate)
        {
            try
            {
                var taskItem = TaskItem.Create(title,  description,  priority, projectId, assignedTo, dueDate);
                var id = _repository.Create(taskItem);

                var createdTask = _repository.Get(id);

                return (TaskItem?)createdTask;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
