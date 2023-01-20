using CMS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Abstraction
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<Course>> GetCourse();
        public Task<Course> GetCourseById(int id);
        public Task AddCourse(Course course);
        public Task DeleteCourse(int id);
        //public Task UpdateCourse(int id, Course course);
    }
}
