using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _department;

        public DepartmentController(IDepartmentRepository department)
        {
            _department = department;
        }

        [HttpGet(Name = "GetAllDepartments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            try
            {
                IEnumerable<Department> allDepartment = await _department.GetAllDepartments();

                if (allDepartment == null)
                {
                    return NotFound();
                }
                return Ok(allDepartment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var departmentById = await _department.GetDepartmentById(id);

                if (departmentById == null)
                {
                    return NotFound();
                }
                return Ok(departmentById);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost(Name = "AddDepartment")]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            try
            {
                if(department == null)
                {
                    return BadRequest();
                }
                await _department.AddDepartment(department);
                return CreatedAtAction("GetAllDepartments", new { id = department.Id }, department);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest();
                }
                await _department.DeleteDepartment(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
