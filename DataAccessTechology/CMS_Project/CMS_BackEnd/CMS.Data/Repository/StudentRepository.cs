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
    public class StudentRepository : IStudentRepository
    {
        private readonly CMSContext _context;

        public StudentRepository(CMSContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Student>> GetStudent() => await _context.Student.ToListAsync();
     
        public async Task<Student> GetStudentById(int id) => await _context.Student.FindAsync(id);
    
        public async Task AddStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
        }

        public Task DeleteStudent(int id)
        {
            var student = _context.Student.Find(id);
            _context.Student.Remove(student);
            return _context.SaveChangesAsync();
        }

        //--------
        //public async Task<IEnumerable<Enrollment>> GetStudentCount()
        //{
        //    return await (from s in _context.Student 
        //                  join e in _context.Enrollment on s.Id equals e.StudentId
        //                  select new Student()
        //                  {
        //                      Id = s.Id,
        //                      CourseCount = s.CourseCount
        //                  }).ToListAsync();
        //}

        public async Task<IEnumerable<Enrollment>> GetStudentNotEnrollCourse(int id)
        {
            return await (from s in _context.Student
                          where s.Id == id
                          join e in _context.Enrollment on s.Id equals e.StudentId
                          select new Enrollment()
                          {
                              Id = e.Id,
                              StudentId = e.StudentId,
                              CourseId = e.CourseId,
                              EnrollmentDate = e.EnrollmentDate
                          }).ToListAsync();
        }

        public int GetStudentNotEnrollCoursecount(int id)
        {
            return (from s in _context.Student
                          where s.Id == id
                          join e in _context.Enrollment on s.Id equals e.StudentId
                          select new Enrollment()
                          {
                              Id = e.Id,
                              StudentId = e.StudentId,
                              CourseId = e.CourseId,
                              EnrollmentDate = e.EnrollmentDate
                          }).Count();
        }

    }
}
