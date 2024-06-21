using AutoMapper;
using DesignPattern.Objects.DTO.Entities;
using DesignPattern.Objects.Models.Entities;
using DesignPattern.Repositories.Interfaces;
using DesignPattern.Services.Interfaces;

namespace DesignPattern.Services.Entities;
public class TaskService : ITaskService
{

    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDTO>> GetAll()
    {
        var tasks = await _taskRepository.GetAll();
        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO> GetById(int id)
    {
        var task = await _taskRepository.GetById(id);
        return _mapper.Map<TaskDTO>(task);
    }

    public async Task Create(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskModel>(taskDTO);
        await _taskRepository.Create(task);
        taskDTO.Id = task.Id;
    }

    public async Task Update(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskModel>(taskDTO);
        await _taskRepository.Update(task);
    }

    public async Task Remove(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskModel>(taskDTO);
        await _taskRepository.Remove(task);
    }
}
