using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CMSContext _context;

        public CourseRepository(CMSContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Course>> GetCourse() => await _context.Course.ToListAsync();
        
        public async Task<Course> GetCourseById(int id) => await _context.Course.FindAsync(id);
        
        public async Task AddCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
        }

        public Task DeleteCourse(int id)
        {
            var course = _context.Course.Find(id);
            _context.Course.Remove(course);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetCourseNotEnrollByStudent(int id)
        {
            return await (from c in _context.Course
                          where c.Id == id
                          join e in _context.Enrollment on c.Id equals e.CourseId
                          select new Course()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Description = c.Description,
                              IsActive = c.IsActive
                          }).ToListAsync();
        }

        public int GetStudentNotEnrollCoursecount(int id)
        {
            return (from c in _context.Course
                    where c.Id == id
                    join e in _context.Enrollment on c.Id equals e.CourseId
                    select new Enrollment()).Count();
        }

    }
}
