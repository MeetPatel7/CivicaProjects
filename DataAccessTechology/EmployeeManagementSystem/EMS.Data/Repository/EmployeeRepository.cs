using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSContext db;

        public EmployeeRepository(EMSContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees() => await db.Employee.ToListAsync();

        public async Task AddEmployee(Employee employee)
        {
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await db.Employee.FindAsync(id);
        }
    }
}