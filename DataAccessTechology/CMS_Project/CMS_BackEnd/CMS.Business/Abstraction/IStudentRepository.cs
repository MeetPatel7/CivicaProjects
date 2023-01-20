using CMS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Abstraction
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetStudent();
        public Task<Student> GetStudentById(int id);
        public Task AddStudent(Student student);
        public Task DeleteStudent(int id);
        public Task<IEnumerable<Enrollment>> GetStudentNotEnrollCourse(int id);
        public int GetStudentNotEnrollCoursecount(int id);
    }
}
