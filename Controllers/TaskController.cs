using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Service.Interfaces;
using TaskManagerApi.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<TaskModel>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<TaskModel>> Get(int id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }

    [HttpPost("Post")]
    public async Task<ActionResult> Post(TaskModel task)
    {
        return Ok(await _service.AddAsync(task));
    }

    [HttpPut("Put/{id}/{task}")]
    public async Task<IActionResult> Put(int id, TaskModel task)
    {
        return Ok(await _service.UpdateAsync(id, task));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}