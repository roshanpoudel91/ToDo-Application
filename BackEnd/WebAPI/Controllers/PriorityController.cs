using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityRepository priorityRepository;

        public PriorityController(IPriorityRepository priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }



        // GET: api/<ProrityController>
        [HttpGet("priority")]
        public async Task<ActionResult<IEnumerable<Priority>>> GetPriorities()
        {
            try
            {
                var result = await priorityRepository.GetAllAsync();
                if (result == null)
                    return BadRequest("No Priority available");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("priority/{id}")]
        public async Task<ActionResult<Priority>> GetPriorities(int id)
        {
            try
            {
                var result = await priorityRepository.GetAsync(id);
                if (result == null)
                    return BadRequest("priority not found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("priority")]
        public virtual async Task<ActionResult<Category>> AddAsync([FromBody] Priority priority)
        {
            try
            {
                if (priority == null)
                    return BadRequest("Invalid Category entity");
                var result = await priorityRepository.AddAsync(priority);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("priority/{id}")]
        public virtual async Task<ActionResult<Priority>> RemoveAsync(int id)
        {
            try
            {
                var result = await priorityRepository.RemoveAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("priority/{id}")]
        public virtual async Task<ActionResult<Category>> UpdateAsync([FromBody] Priority priority, int id)
        {
            try
            {
                if (priority == null)
                {
                    return BadRequest("Invalid Priority Type");
                }
                var result = await priorityRepository.UpdateAsync(priority, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
