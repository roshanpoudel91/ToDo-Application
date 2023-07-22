using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly ITodoRepository todoRepository;
        private readonly ApiDataContext databaseContext;

        public ToDoController(ITodoRepository todoRepository, ApiDataContext databaseContext)
        {
            this.todoRepository = todoRepository;
            this.databaseContext = databaseContext;
           
                    

        }


        // GET: api/<CategoryController>
        [HttpGet("ToDo")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos()
        {
            /*try
            {
                var result = await todoRepository.GetAllAsync();
                if (result == null)
                    return BadRequest("No ToDo available");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/

            Console.WriteLine("inside todo docs");
            var todos = databaseContext.ToDos
                .Include(x => x.Categories)
                .Include(x => x.Priorities)
                .Include(x => x.Users)
                .ToList();

            return todos;


        }

         [HttpGet("toDo/{id}")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos(int id)
        {

            /* try
             {
                 var result = await todoRepository.GetAsync(id);
                 if (result == null)
                     return BadRequest("ToDo not found");

                 return Ok(result);
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }*/

            Console.WriteLine("inside todo docs");
            var todos = databaseContext.ToDos
                .Where(todo => todo.Id == id)
                .Include(x => x.Categories)
                .Include(x => x.Priorities)
                .Include(x => x.Users)
                .ToList();
                

            return todos;




        }


        [HttpPost("toDo")]
        public virtual async Task<ActionResult<ToDo>> AddAsync([FromBody] ToDo toDo)
        {
            try
            {
                if (toDo == null)
                    return BadRequest("Invalid ToDo entity");
                var result = await todoRepository.AddAsync(toDo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("toDo/{id}")]
        public virtual async Task<ActionResult<ToDo>> RemoveAsync(int id)
        {
            try
            {
                var result = await todoRepository.RemoveAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("toDo/{id}")]
        public virtual async Task<ActionResult<ToDo>> UpdateAsync([FromBody] ToDo toDo, int id)
        {
            try
            {
                if (toDo == null)
                {
                    return BadRequest("Invalid ToDo Type");
                }
                var result = await todoRepository.UpdateAsync(toDo, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }


    }
