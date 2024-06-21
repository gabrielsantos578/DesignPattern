using DesignPattern.Objects.DTO.Entities;

namespace DesignPattern.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAll();
        Task<TaskDTO> GetById(int id);
        Task Create(TaskDTO taskDTO);
        Task Update(TaskDTO taskDTO);
        Task Remove(TaskDTO taskDTO);
    }
}
