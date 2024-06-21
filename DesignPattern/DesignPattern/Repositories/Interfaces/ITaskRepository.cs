using DesignPattern.Objects.Models.Entities;

namespace DesignPattern.Repositories.Interfaces
{
    public interface ITaskRepository
	{
		Task<IEnumerable<TaskModel>> GetAll();
		Task<TaskModel> GetById(int id);
		Task<TaskModel> Create(TaskModel taskModel);
		Task<TaskModel> Update(TaskModel taskModel);
		Task<TaskModel> Remove(TaskModel taskModel);
	}
}
