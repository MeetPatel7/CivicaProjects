using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Business.Entities;

namespace EMS.Business.Abstraction
{
    public interface IEmployeeRepository
    {

        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task AddEmployee(Employee Employee);
        public Task UpdateEmployee(Employee Employee);
    }
}
