using EMS.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Abstraction
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> GetAllDepartments();
        public Task<Department> GetDepartmentById(int id);
        public Task AddDepartment(Department department);
        public Task DeleteDepartment(int id);
    }
}
