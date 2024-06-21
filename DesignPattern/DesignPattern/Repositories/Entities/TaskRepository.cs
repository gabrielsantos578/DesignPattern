using DesignPattern.Context;
using DesignPattern.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DesignPattern.Objects.Models.Entities;

namespace DesignPattern.Repositories.Entities;
public class TaskRepository : ITaskRepository
{

    private readonly AppDBContext _dbContext;

    public TaskRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TaskModel>> GetAll()
    {
        return await _dbContext.Task.AsNoTracking().ToListAsync();
    }

    public async Task<TaskModel> GetById(int id)
    {
        return await _dbContext.Task.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskModel> Create(TaskModel taskModel)
    {
        _dbContext.Task.Add(taskModel);
        await _dbContext.SaveChangesAsync();
        return taskModel;
    }

    public async Task<TaskModel> Update(TaskModel taskModel)
    {
        _dbContext.Entry(taskModel).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return taskModel;
    }

    public async Task<TaskModel> Remove(TaskModel taskModel)
    {
        _dbContext.Task.Remove(taskModel);
        await _dbContext.SaveChangesAsync();
        return taskModel;
    }
}
