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
        private readonly EMSContext _context;

        public DepartmentController(EMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            return await _context.Department.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllDepartments", new { id = department.Id }, department);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var Department = await _context.Department.FindAsync(id);

            if (Department == null)
            {
                return NotFound();
            }
            return Department;
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            _context.Entry(department).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            if (!DepartmentExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
