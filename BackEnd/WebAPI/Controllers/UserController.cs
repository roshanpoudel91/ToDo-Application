using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DataTransferObjects;
using System.Data.Entity;
using System.Dynamic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;
        private readonly ApiDataContext dataContext;

        public UserController(ILogger<UserController> logger,
            IUserService userService, ApiDataContext dataContext)
        {
            _logger = logger;
            this.userService = userService;
            this.dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<UserView>> Add([FromBody] UserView user)
        {
            try
            {
                if (User == null)
                {
                    return BadRequest("Invalid User");
                }

                var result = await userService.AddAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("role/{role}")]
        public async Task<ActionResult<ICollection<UserView>>> GetUsersByRole(string role)
        {
            try
            {
                if (string.IsNullOrEmpty(role))
                {
                    return BadRequest("Invalid role");
                }
                
                var result = await userService.GetAllByRole(role);
                if (result == null)
                {
                    return BadRequest($"No Users available with role of {role}");
                }

              foreach(var user in result)
                {
                    if (dataContext.ToDos.Any(x => x.UserId == user.Id))
                    {
                        user.IsTodo = true;
                    }

                }

               

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserView>>> GetUsers()
        {
            try
            {
                var result = await userService.GetAllAsync();
                if (result == null)
                {
                    return BadRequest("No Users available");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserView>> GetUser(string id)
        {
            try
            {
                UserView result = await userService.GetAsync(id);
                if (result == null)
                {
                    return BadRequest("User not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserView>> UpdateAsync([FromBody] UserView user, string id)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(id))
                {
                    return BadRequest("Invalid User");
                }

                UserView result = await userService.UpdateAsync(user, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserView>> RemoveAsync(string id)
        {
            try
            {
                if (this.dataContext.ToDos.Any(x => x.UserId == id))
                {
                    // user cannot be deleted because this user has one
                    // or more ToDo's associated to this user
                    return BadRequest("This user cannot be deleted because it is linked with one or more todo items.");
                }
                else
                {
                    // okay to delete user
                    UserView result = await userService.RemoveAsync(id);
                    return Ok(result);
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}