using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class TaskItemDto
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Description { get; private set; }
        [Required]
        public TaskItemPriority Priority { get; private set; }
        public int? ProjectId { get; }
        public User? AssignedTo { get; private set; } // pomocne w nawigacji między zadaniem i użytkownikiem
        public DateTime? DueDate { get; private set; }

        public TaskItemDto(string title, string description, TaskItemPriority priority, int? projectId, User? assignedTo, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            Priority = priority;
            ProjectId = projectId;
            AssignedTo = assignedTo;
            DueDate = dueDate;
        }
    }
}
