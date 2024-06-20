using SGED.Objects.Models.Entities;

namespace SGED.Repositories.Interfaces;
public interface IEstadoRepository
{
    Task<IEnumerable<Task>> GetAll();
    Task<Task> GetById(int id);
    Task<IEnumerable<Task>> GetByName(string nome);
    Task<Task> Create(Objects.Models.Entities.Task estado);
    Task<Task> Update(Objects.Models.Entities.Task estado);
    Task<Task> Delete(int id);
}