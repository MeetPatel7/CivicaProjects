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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet(Name = "GetAllEmployees")]
        public async Task<ActionResult<Employee>> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employeeData = await _employee.GetAllEmployees();

                if(employeeData == null)
                {
                    return NotFound();
                }
                return Ok(employeeData);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employeeById = await _employee.GetEmployeeById(id);

                if (employeeById == null)
                {
                    return NotFound();
                }
                return Ok(employeeById);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }
                await _employee.AddEmployee(employee);
                return CreatedAtAction("GetAllEmployees", new { id = employee.Id },employee);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if(employee == null || id != employee.Id)
                {
                    return BadRequest();
                }
                await _employee.UpdateEmployee(employee);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
    }
}

