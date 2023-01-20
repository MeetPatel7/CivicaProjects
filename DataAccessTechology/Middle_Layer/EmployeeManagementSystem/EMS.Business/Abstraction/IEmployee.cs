using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Business.Entities;

namespace EMS.Business.Abstraction
{
    public interface IEmployee
    {

        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        List<Employee> AddEmployee(Employee Employee);
        Employee UpdateEmployee(Employee Employee);
    }
}
