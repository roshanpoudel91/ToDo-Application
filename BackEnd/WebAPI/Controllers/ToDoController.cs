using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ITodoRepository todoRepository;

        public ToDoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;

        }


        // GET: api/<CategoryController>
        [HttpGet("ToDo")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
        {
            try
            {
                var result = await todoRepository.GetAllAsync();
                if (result == null)
                    return BadRequest("No ToDo available");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
