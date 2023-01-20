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
    public class DepartmentRepository : IDepartment
    {
        private readonly EMSContext db;

        public DepartmentRepository(EMSContext db)
        {
            this.db = db;
        }

        public List<Department> GetAllDepartments() => db.Department.ToList();

        public List<Department> AddDepartment(Department department)
        {
            db.Department.Add(department);
            db.SaveChanges();
            return db.Department.ToList();
        }

        public Department UpdateDepartment(Department department)
        {
            db.Department.Update(department);
            db.SaveChanges();
            return db.Department.Where(x => x.Id == department.Id).FirstOrDefault();
        }

        public Department GetDepartmentById(int Id)
        {
            return db.Department.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
