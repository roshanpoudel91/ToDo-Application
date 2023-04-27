using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DataTransferObjects;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
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
                UserView result = await userService.RemoveAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}