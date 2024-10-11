using TaskManagerApi.ViewModels;

namespace TaskManagerApi.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllAsync();
        Task<TaskModel> GetById(int id);
        Task<int> AddAsync(TaskModel obj);
        Task<int> UpdateAsync(int id, TaskModel obj);
        Task<int> DeleteAsync(int id);
    }
}