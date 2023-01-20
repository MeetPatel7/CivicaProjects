using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSS.Business.Abstraction;
using OSS.Business.Entity;

namespace OSS.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categories;

        public CategoriesController(ICategoriesRepository categories)
        {
            _categories = categories;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            try
            {
                var getCategories = await _categories.GetCategories();

                if(getCategories == null)
                {
                    return NotFound();
                }
                return Ok(getCategories);

            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategoriesById(int id)
        {
            try
            {
                var getCategoriesById = await _categories.GetCategoriesById(id);

                if (getCategoriesById == null)
                {
                    return NotFound();
                }
                return Ok(getCategoriesById);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categories>> AddCategories(Categories categories)
        {
            try
            {
                if (categories == null)
                {
                    return BadRequest();
                }
                await _categories.AddCategories(categories);
                return CreatedAtAction("GetCategories",new {id = categories.Id},categories);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> DeteleCategories(int id)
        {
            try
            {
                //var deleteCategories = await _categories.GetCategoriesById(id);
                if(id == 0)
                {
                    return BadRequest();
                }
                await _categories.DeleteCategories(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categories>> UpdateCategories(int id,Categories categories)
        {
            try
            {
                //var updateCategories = await _categories.GetCategoriesById(id);
                if(categories == null || id != categories.Id)
                {
                    return BadRequest();
                }
                await _categories.UpdateCategories(id, categories);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
    }
}
