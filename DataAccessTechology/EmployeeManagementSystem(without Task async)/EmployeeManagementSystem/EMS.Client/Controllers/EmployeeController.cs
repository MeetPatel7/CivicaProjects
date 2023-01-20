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

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                List<Employee> allEmployee = _employee.GetAllEmployees();

                if(allEmployee == null)
                {
                    return BadRequest();
                }
                return Ok(allEmployee);
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                //return Ok(allEmployee);
                _employee.AddEmployee(employee);
                return CreatedAtAction("GetAllEmployee", new { id = employee.Id }, employee);
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
            //_employee.Employee.Add(employee);
            //_employee.SaveChangesAsync();

            //return CreatedAtAction("GetAllEmployees", new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employeeById =  _employee.GetEmployeeById(id);

            if (employeeById == null)
            {
                return NotFound();
            }
            return Ok(employeeById);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                //var updateEmployee = _employee.UpdateEmployee(employee);
                if(employee == null || id != employee.Id || id == 0)
                {
                    return BadRequest();
                }

            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }


            //if (id != employee.Id)
            //{
            //    return BadRequest();
            //}
            //_context.Entry(employee).State = EntityState.Modified;

            //await _context.SaveChangesAsync();

            //if (!EmployeeExists(id))
            //{
            //    return NotFound();
            //}
            //return NoContent();
        }
    }
}

