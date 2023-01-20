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
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        List<Department> AddDepartment(Department department);
        List<Department> DeleteDepartment(int id);
    }
}
