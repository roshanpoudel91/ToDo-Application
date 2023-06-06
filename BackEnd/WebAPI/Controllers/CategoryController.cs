using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        // GET: api/<CategoryController>
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetGategories()
        {
            try
            {
                var result = await categoryRepository.GetAllAsync();
                if (result == null)
                    return BadRequest("No Category available");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Category>> GetCategories(int id)
        {
            try
            {
                var result = await categoryRepository.GetAsync(id);
                if (result == null)
                    return BadRequest("Category not found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("category")]
        public virtual async Task<ActionResult<Category>> AddAsync([FromBody] Category category)
        {
            try
            {
                if (category == null)
                    return BadRequest("Invalid Category entity");
                var result = await categoryRepository.AddAsync(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("category/{id}")]
        public virtual async Task<ActionResult<Category>> RemoveAsync(int id)
        {
            try
            {
                var result = await categoryRepository.RemoveAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
