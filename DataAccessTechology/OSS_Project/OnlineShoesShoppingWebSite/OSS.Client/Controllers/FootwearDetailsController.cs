using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSS.Business.Abstraction;
using OSS.Business.Entity;

namespace OSS.Client.Controllers
{
    [Route("api")]
    [ApiController]
    public class FootwearDetailsController : ControllerBase
    {
        private readonly IFootwearDetailsRepository _footwearDetails;

        public FootwearDetailsController(IFootwearDetailsRepository footwearDetails)
        {
            _footwearDetails = footwearDetails;
        }

        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<FootwearDetails>>> GetFootwearDetails()
        {
            try
            {
                var getFootwearDetails = await _footwearDetails.GetFootwearDetails();

                if (getFootwearDetails == null)
                {
                    return NotFound();
                }
                return Ok(getFootwearDetails);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<FootwearDetails>> GetFootwearDetailsById(int id)
        {
            try
            {
                var getFootwearDetailsById = await _footwearDetails.GetFootwearDetailsById(id);

                if (getFootwearDetailsById == null)
                {
                    return NotFound();
                }
                return Ok(getFootwearDetailsById);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("[controller]")]
        public async Task<ActionResult<FootwearDetails>> AddFootwearDetails(FootwearDetails footwearDetails)
        {
            try
            {
                if (footwearDetails == null)
                {
                    return BadRequest();
                }
                await _footwearDetails.AddFootwearDetails(footwearDetails);
                return CreatedAtAction("GetFootwearDetails", new { id = footwearDetails.Id }, footwearDetails);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("[controller]/{id}")]
        public async Task<ActionResult<FootwearDetails>> DeteleFootwearDetails(int id)
        {
            try
            {
                //var deleteCategories = await _categories.GetCategoriesById(id);
                if (id == 0)
                {
                    return BadRequest();
                }
                await _footwearDetails.DeleteFootwearDetails(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("[controller]/{id}")]
        public async Task<ActionResult<FootwearDetails>> UpdateFootwearDetails(int id, FootwearDetails footwearDetails)
        {
            try
            {
                //var updateCategories = await _categories.GetCategoriesById(id);
                if (footwearDetails == null || id != footwearDetails.Id)
                {
                    return BadRequest();
                }
                await _footwearDetails.UpdateFootwearDetails(id, footwearDetails);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Categories/{categoryId}/[controller]")]
        public async Task<ActionResult<IEnumerable<FootwearDetails>>> GetFootwearDetailsByCategoryId(int categoryId)
        {
            try
            {
                var getFootwearDetailsByCategoryId = await _footwearDetails.GetFootwearDetailsByCategoryId(categoryId);
                if(getFootwearDetailsByCategoryId == null)
                {
                    return NotFound();
                }
                return Ok(getFootwearDetailsByCategoryId);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Categories/{categoryId}/[controller]/{id}")]
        public async Task<ActionResult<IEnumerable<FootwearDetails>>> GetFootwearDetailsByCategoryIdAndFootwearDetailsId(int categoryId,int id)
        {
            try
            {
                var getFootwearDetailsByCategoryIdAndFootwearDetailsId = await _footwearDetails.GetFootwearDetailsByCategoryIdAndFootwearDetailsId(categoryId,id);
                if (getFootwearDetailsByCategoryIdAndFootwearDetailsId == null)
                {
                    return NotFound();
                }
                return Ok(getFootwearDetailsByCategoryIdAndFootwearDetailsId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
