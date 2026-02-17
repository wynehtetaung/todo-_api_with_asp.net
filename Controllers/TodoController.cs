using Microsoft.AspNetCore.Mvc;
using TodoModel;
using TodoServiceApi;

[ApiController]
[Route("api/[controller]")]

public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Todo>> Get() => _service.Get();

    [HttpGet("{id}")]

    public ActionResult<Todo> Get(string id)
    {
        var todoItem = _service.Get(id);
        if(todoItem == null)
        {
            return NotFound(new {message = "Item Not Found!"});
        }
        return Ok(todoItem);
    } 

    [HttpPost]
    public ActionResult<Todo> Create(Todo todo)
    {
        todo.Check = false;
        _service.Create(todo);
        return todo;
    }

    [HttpPatch("{id}")]
    public ActionResult<Todo> Update(string id)
    {
        _service.Update(id);
        return Ok(new {message = "Updated"});
        
    }

    [HttpPut("{id}")]
    public ActionResult<Todo> Update(string id, Todo todo)
    {
        _service.Update(id, todo);
        return Ok(new {message = "item updated"});
    }

    [HttpDelete("{id}")]
    public ActionResult<Todo> Delete(string id)
    {
        var todoList = _service.Get();
        if(!todoList.Any(t => t.Id == id))
        {
            return NotFound(new {message = "item not found!"});
        }
        _service.Delete(id);
        return NoContent();
    }

    [HttpDelete]
    public ActionResult<Todo> DeleteItem (string option)
    {
        _service.DeleteItem(option);
        return NoContent();
    }
}