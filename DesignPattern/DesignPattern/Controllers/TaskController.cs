using Microsoft.AspNetCore.Mvc;
using DesignPattern.Services.Interfaces;
using DesignPattern.Objects.DTO.Entities;
using DesignPattern.Objects.Enums;

namespace DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet(Name = "GetAllTasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            var existingTasks = await _taskService.GetAll();
            return Ok(existingTasks);
        }

        [HttpGet("{id:int}", Name = "GetTask")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            var existingTask = await _taskService.GetById(id);
            return existingTask is not null ?
                Ok(existingTask) :
                NotFound("Tarefa não encontrada!");
        }

        [HttpGet("{id:int}/State", Name = "GetTaskState")]
        public async Task<ActionResult<TaskDTO>> GetState(int id)
        {
            var existingTask = await _taskService.GetById(id);
            return existingTask is not null ?
                Ok("A tarefa está na área " + ETaskStateExtensions.GetState(existingTask.State) + ".") :
                NotFound("Tarefa não encontrada!");
        }

        [HttpPost(Name = "PostTask")]
        public async Task<ActionResult> Post([FromBody] TaskDTO taskDTO)
        {
            if (taskDTO is null)
            {
                return BadRequest("Dado(s) inválido(s)!");
            }

            taskDTO.State = ETaskState.Create;
            await _taskService.Create(taskDTO);

            return CreatedAtRoute("GetTask", new { id = taskDTO.Id }, taskDTO);
        }

        [HttpPut(Name = "PutState")]
        public async Task<ActionResult> Put([FromBody] TaskDTO taskDTO)
        {
            if (taskDTO is null)
            {
                return BadRequest("Dado(s) inválido(s)!");
            }

            var existingTask = await _taskService.GetById(taskDTO.Id);

            if (existingTask is null)
            {
                return BadRequest("A tarefa informada não existe!");
            }
            else if (existingTask.State != ETaskState.Create)
            {
                return BadRequest("Não é possível alterar a tarefa porque ela está na área " + ETaskStateExtensions.GetState(existingTask.State) + "!");
            }

            taskDTO.State = existingTask.State;
            await _taskService.Update(taskDTO);

            return Ok(taskDTO);
        }

        [HttpPut("{id:int}/InProgress", Name = "InProgressState")]
        public async Task<ActionResult<TaskDTO>> InProgress(int id)
        {
            var existingTask = await _taskService.GetById(id);

            if (existingTask is null)
            {
                return NotFound("Tarefa não encontrada!");
            }
            else if (!existingTask.InProgress())
            {
                return BadRequest(existingTask.Error);
            }

            await _taskService.Update(existingTask);

            return Ok("Tarefa movida para a área " + ETaskStateExtensions.GetState(existingTask.State) + ".");
        }

        [HttpPut("{id:int}/Concluded", Name = "ConcludedState")]
        public async Task<ActionResult<TaskDTO>> Concluded(int id)
        {
            var existingTask = await _taskService.GetById(id);

            if (existingTask is null)
            {
                return NotFound("Tarefa não encontrada!");
            }
            else if (!existingTask.Concluded())
            {
                return BadRequest(existingTask.Error);
            }

            await _taskService.Update(existingTask);

            return Ok("Tarefa movida para a área " + ETaskStateExtensions.GetState(existingTask.State) + ".");
        }

        [HttpPut("{id:int}/Canceled", Name = "CanceledState")]
        public async Task<ActionResult<TaskDTO>> Canceled(int id)
        {
            var existingTask = await _taskService.GetById(id);

            if (existingTask is null)
            {
                return NotFound("Tarefa não encontrada!");
            }
            else if (!existingTask.Canceled())
            {
                return BadRequest(existingTask.Error);
            }

            await _taskService.Update(existingTask);

            return Ok("Tarefa movida para a área " + ETaskStateExtensions.GetState(existingTask.State) + ".");
        }

        [HttpDelete("{id:int}", Name = "RemoveTask")]
        public async Task<ActionResult<TaskDTO>> Remove(int id)
        {
            var existingTask = await _taskService.GetById(id);

            if (existingTask is null)
            {
                return NotFound("Tarefa não encontrada!");
            }
            else if (existingTask.State != ETaskState.Create && existingTask.State != ETaskState.Canceled)
            {
                return BadRequest("Não é possível excluir a tarefa porque ela está na área " + ETaskStateExtensions.GetState(existingTask.State) + "!");
            }

            await _taskService.Remove(existingTask);

            return Ok(existingTask);
        }
    }
}
