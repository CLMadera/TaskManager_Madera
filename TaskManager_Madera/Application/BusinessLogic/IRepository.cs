namespace TaskManager.BusinessLogic
{
    public interface IRepository
    {
        Task<User[]> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<int> CreateTaskItemAsync(TaskItem newTaskItem);
        Task<bool> UpdateTaskItemAsync(TaskItem newTaskItem);
        Task<bool> DeleteTaskItemAsync(int taskItemId);
        Task<TaskItem?> GetTaskItemByIdAsync(int taskItemId);
        Task<TaskItem[]> GetAllTaskItemsAsync();
        Task<TaskItem[]> GetTaskItemsByStatusAsync(TaskItemStatus status);
        Task<TaskItem[]> GetTaskItemsByDescriptionAsync(string description);
        Task<IEnumerable<SeriLog>> GetAllAsync();
        Task<SeriLog> GetByIdAsync(int id);
        Task<IEnumerable<LogCountByDayDto>> GetLogCountByDayAsync();
        Task<IEnumerable<SeriLog>> GetByLogLevelAsync(string logLevel);
        Task<IEnumerable<SeriLog>> GetByMessageAsync(string searchTerm);

    }
}