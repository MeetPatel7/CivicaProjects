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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EMSContext db;

        public DepartmentRepository(EMSContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments() => await db.Department.ToListAsync();

        public async Task AddDepartment(Department department)
        {
            db.Department.Add(department);
            await db.SaveChangesAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await db.Department.FindAsync(id);
        }

        public Task DeleteDepartment(int id)
        {
            var deleteDepartment = db.Department.Find(id);
            db.Department.Remove(deleteDepartment);
            return db.SaveChangesAsync();
        }
    }
}
