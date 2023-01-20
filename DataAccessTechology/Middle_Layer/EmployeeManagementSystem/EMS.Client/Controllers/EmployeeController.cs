using EMS.Business.Entities;
using EMS.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EMSContext _context;

        public EmployeeController(EMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllEmployees", new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var Employee = await _context.Employee.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            if (!EmployeeExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

