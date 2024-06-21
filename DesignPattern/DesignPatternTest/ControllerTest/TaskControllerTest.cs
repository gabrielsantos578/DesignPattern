using Microsoft.AspNetCore.Mvc;
using Moq;
using DesignPattern.Controllers;
using DesignPattern.Objects.DTO.Entities;
using DesignPattern.Objects.Enums;
using DesignPattern.Services.Interfaces;

namespace DesignPatternTest.ControllerTest
{
    [TestFixture]
    public class TaskControllerTests
    {
        private Mock<ITaskService> _taskServiceMock;
        private TaskController _taskController;

        [SetUp]
        public void Setup()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _taskController = new TaskController(_taskServiceMock.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkWithTasks()
        {
            var tasks = new List<TaskDTO> { new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.Create } };
            _taskServiceMock.Setup(service => service.GetAll()).ReturnsAsync(tasks);

            var result = await _taskController.GetAll();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(tasks, okResult.Value);
        }

        [Test]
        public async Task GetById_ReturnsOkWithTask()
        {
            var task = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.Create };
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync(task);

            var result = await _taskController.GetById(1);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(task, okResult.Value);
        }

        [Test]
        public async Task GetById_ReturnsNotFoundWhenTaskNotFound()
        {
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.GetById(1);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }

        [Test]
        public async Task GetState_ReturnsOkWithTaskState()
        {
            var taskId = 1;
            var task = new TaskDTO { Id = taskId, Name = "Task 1", State = ETaskState.InProgress };
            _taskServiceMock.Setup(service => service.GetById(taskId)).ReturnsAsync(task);

            var result = await _taskController.GetState(taskId);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual($"A tarefa está na área {ETaskStateExtensions.GetState(task.State)}.", okResult.Value);
        }

        [Test]
        public async Task GetState_ReturnsNotFoundWhenTaskNotFound()
        {
            var taskId = 1;
            _taskServiceMock.Setup(service => service.GetById(taskId)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.GetState(taskId);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }

        [Test]
        public async Task Post_ReturnsCreatedAtRoute()
        {
            var newTask = new TaskDTO { Id = 1, Name = "New Task", State = ETaskState.Create };
            _taskServiceMock.Setup(service => service.Create(newTask)).Returns(Task.CompletedTask);

            var result = await _taskController.Post(newTask);

            var createdAtRouteResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(createdAtRouteResult);
            Assert.AreEqual(201, createdAtRouteResult.StatusCode);
            Assert.AreEqual("GetTask", createdAtRouteResult.RouteName);
            Assert.AreEqual(newTask.Id, createdAtRouteResult.RouteValues["id"]);
            Assert.AreEqual(newTask, createdAtRouteResult.Value);
        }

        [Test]
        public async Task Post_ReturnsBadRequestWhenTaskDTOIsNull()
        {
            var result = await _taskController.Post(null);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Dado(s) inválido(s)!", badRequestResult.Value);
        }

        [Test]
        public async Task Put_ReturnsOkWithUpdatedTask()
        {
            var existingTask = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.Create };
            _taskServiceMock.Setup(service => service.GetById(existingTask.Id)).ReturnsAsync(existingTask);
            _taskServiceMock.Setup(service => service.Update(existingTask)).Returns(Task.CompletedTask);

            var result = await _taskController.Put(existingTask);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(existingTask, okResult.Value);
        }

        [Test]
        public async Task Put_ReturnsBadRequestWhenTaskDTOIsNull()
        {
            var result = await _taskController.Put(null);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Dado(s) inválido(s)!", badRequestResult.Value);
        }

        [Test]
        public async Task InProgress_ReturnsOkWithMessage()
        {
            var existingTask = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.Create };
            _taskServiceMock.Setup(service => service.GetById(existingTask.Id)).ReturnsAsync(existingTask);
            _taskServiceMock.Setup(service => service.Update(existingTask)).Returns(Task.CompletedTask);

            var result = await _taskController.InProgress(existingTask.Id);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual($"Tarefa movida para a área {ETaskStateExtensions.GetState(existingTask.State)}.", okResult.Value);
        }

        [Test]
        public async Task InProgress_ReturnsBadRequestWhenTaskNotFound()
        {
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.InProgress(1);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }

        [Test]
        public async Task Concluded_ReturnsOkWithMessage()
        {
            var existingTask = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.InProgress };
            _taskServiceMock.Setup(service => service.GetById(existingTask.Id)).ReturnsAsync(existingTask);
            _taskServiceMock.Setup(service => service.Update(existingTask)).Returns(Task.CompletedTask);

            var result = await _taskController.Concluded(existingTask.Id);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual($"Tarefa movida para a área {ETaskStateExtensions.GetState(existingTask.State)}.", okResult.Value);
        }

        [Test]
        public async Task Concluded_ReturnsBadRequestWhenTaskNotFound()
        {
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.Concluded(1);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }

        [Test]
        public async Task Canceled_ReturnsOkWithMessage()
        {
            var existingTask = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.InProgress };
            _taskServiceMock.Setup(service => service.GetById(existingTask.Id)).ReturnsAsync(existingTask);
            _taskServiceMock.Setup(service => service.Update(existingTask)).Returns(Task.CompletedTask);

            var result = await _taskController.Canceled(existingTask.Id);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual($"Tarefa movida para a área {ETaskStateExtensions.GetState(existingTask.State)}.", okResult.Value);
        }

        [Test]
        public async Task Canceled_ReturnsBadRequestWhenTaskNotFound()
        {
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.Canceled(1);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }

        [Test]
        public async Task Remove_ReturnsOkWithDeletedTask()
        {
            var existingTask = new TaskDTO { Id = 1, Name = "Task 1", State = ETaskState.Create };
            _taskServiceMock.Setup(service => service.GetById(existingTask.Id)).ReturnsAsync(existingTask);
            _taskServiceMock.Setup(service => service.Remove(existingTask)).Returns(Task.CompletedTask);

            var result = await _taskController.Remove(existingTask.Id);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(existingTask, okResult.Value);
        }

        [Test]
        public async Task Remove_ReturnsNotFoundWhenTaskNotFound()
        {
            _taskServiceMock.Setup(service => service.GetById(1)).ReturnsAsync((TaskDTO)null);

            var result = await _taskController.Remove(1);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
            Assert.AreEqual("Tarefa não encontrada!", notFoundResult.Value);
        }
    }
}
