using Domain.Models;

namespace Application.Services
{
    public interface ITaskItemService
    {
        TaskItem? Create (string title, string description, TaskItemPriority priority, int? projectId,
            User? assignedTo, DateTime? dueDate);
    }
}