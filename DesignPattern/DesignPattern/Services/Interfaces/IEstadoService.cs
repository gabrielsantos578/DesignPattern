using SGED.Objects.DTO.Entities;

namespace SGED.Services.Interfaces
{
    public interface IEstadoService
    {
        Task<IEnumerable<TaskDTO>> GetAll();
        Task<TaskDTO> GetById(int id);
        Task<IEnumerable<TaskDTO>> GetByName(string nome);
        Task Create(TaskDTO estadoDTO);
        Task Update(TaskDTO estadoDTO);
        Task Remove(int id);
    }
}
