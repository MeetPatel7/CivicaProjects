using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Data.Entities;
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

        public List<Employee> GetAllEmployees() => db.Employee.ToList();

        public List<Employee> AddEmployee(Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges();
            return db.Employee.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            db.Employee.Update(employee);
            db.SaveChanges();
            return db.Employee.Where(x => x.Id == employee.Id).FirstOrDefault();
        }

        public Employee GetEmployeeById(int Id)
        {
            return db.Employee.Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}

