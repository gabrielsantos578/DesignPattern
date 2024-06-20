using AutoMapper;
using SGED.Objects.DTO.Entities;
using SGED.Objects.Models.Entities;
using SGED.Repositories.Interfaces;
using SGED.Services.Interfaces;

namespace SGED.Services.Entities;
public class EstadoService : IEstadoService
{

	private readonly IEstadoRepository _estadoRepository;
	private readonly IMapper _mapper;

	public EstadoService(IEstadoRepository estadoRepository, IMapper mapper)
	{
		_estadoRepository = estadoRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<TaskDTO>> GetAll()
	{
		var estados = await _estadoRepository.GetAll();
		return _mapper.Map<IEnumerable<TaskDTO>>(estados);
	}

	public async Task<TaskDTO> GetById(int id)
	{
		var estado = await _estadoRepository.GetById(id);
		return _mapper.Map<TaskDTO>(estado);
	}

    public async Task<IEnumerable<TaskDTO>> GetByName(string nome)
    {
        var estados = await _estadoRepository.GetByName(nome);
        return _mapper.Map<IEnumerable<TaskDTO>>(estados);
    }

    public async System.Threading.Tasks.Task Create(TaskDTO estadoDTO)
	{
		var estado = _mapper.Map<Objects.Models.Entities.Task>(estadoDTO);
		await _estadoRepository.Create(estado);
		estadoDTO.Id = estado.Id;
	}

	public async System.Threading.Tasks.Task Update(TaskDTO estadoDTO)
	{
		var estado = _mapper.Map<Objects.Models.Entities.Task>(estadoDTO);
		await _estadoRepository.Update(estado);
	}

	public async System.Threading.Tasks.Task Remove(int id)
	{
		await _estadoRepository.Delete(id);
	}
}
