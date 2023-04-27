using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DataTransferObjects;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger,
            IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<RoleView>> Add([FromBody] RoleView role)
        {
            try
            {
                if (role == null)
                {
                    return BadRequest("Invalid Role");
                }

                var result = await _roleService.AddAsync(role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RoleView>>> GetAll()
        {
            try
            {
                var result = await _roleService.GetAllAsync();
                if (result == null)
                {
                    return BadRequest("No Roles available");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleView>> GetRole(string id)
        {
            try
            {
                RoleView result = await _roleService.GetAsync(id);
                if (result == null)
                {
                    return BadRequest("Role not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleView>> UpdateAsync([FromBody] RoleView role, string id)
        {
            try
            {
                if (role == null || string.IsNullOrEmpty(id))
                {
                    return BadRequest("Invalid Role");
                }

                RoleView result = await _roleService.UpdateAsync(role, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleView>> RemoveAsync(string id)
        {
            try
            {
                RoleView result = await _roleService.RemoveAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}