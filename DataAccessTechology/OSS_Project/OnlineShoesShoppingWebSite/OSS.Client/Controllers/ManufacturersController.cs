using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSS.Business.Abstraction;
using OSS.Business.Entity;

namespace OSS.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturersRepository _manufacturers;

        public ManufacturersController(IManufacturersRepository manufacturers)
        {
            _manufacturers = manufacturers;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturers>>> GetManufacturers()
        {
            try
            {
                var getManufacturers = await _manufacturers.GetManufacturers();

                if (getManufacturers == null)
                {
                    return NotFound();
                }
                return Ok(getManufacturers);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturers>> GetManufacturersById(int id)
        {
            try
            {
                var getManufacturersById = await _manufacturers.GetManufacturersById(id);

                if (getManufacturersById == null)
                {
                    return NotFound();
                }
                return Ok(getManufacturersById);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Manufacturers>> AddManufacturers(Manufacturers manufacturers)
        {
            try
            {
                if (manufacturers == null)
                {
                    return BadRequest();
                }
                await _manufacturers.AddManufacturers(manufacturers);
                return CreatedAtAction("GetManufacturers", new { id = manufacturers.Id }, manufacturers);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacturers>> DeteleManufacturers(int id)
        {
            try
            {
                //var deleteCategories = await _categories.GetCategoriesById(id);
                if (id == 0)
                {
                    return BadRequest();
                }
                await _manufacturers.DeleteManufacturers(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Manufacturers>> UpdateManufacturers(int id, Manufacturers manufacturers)
        {
            try
            {
                //var updateCategories = await _categories.GetCategoriesById(id);
                if (manufacturers == null || id != manufacturers.Id)
                {
                    return BadRequest();
                }
                await _manufacturers.UpdateManufacturers(id, manufacturers);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
