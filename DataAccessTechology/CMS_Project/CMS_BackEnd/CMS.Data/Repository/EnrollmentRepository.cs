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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly CMSContext _context;
        public EnrollmentRepository(CMSContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollment()
        {
            return await _context.Enrollment.ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            return await _context.Enrollment.FirstAsync(x => x.Id == id);
        }

        public async Task AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollment.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public int GetStudentEnrollCourseCount(int id)
        {
            return (from s in _context.Student
                    where s.Id == id
                    join e in _context.Enrollment on s.Id equals e.StudentId
                    select new Enrollment()).Count();
        }

        public int GetEnrollCourseCount(int sid,int cid)
        {
            return (from s in _context.Student
                    join e in _context.Enrollment on s.Id equals e.StudentId
                    join c in _context.Course on e.CourseId equals c.Id
                    where s.Id == sid && c.Id == cid
                    select new Enrollment()).Count();
        }

    }
}
