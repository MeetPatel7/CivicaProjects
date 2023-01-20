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

        //public async Task DeleteEnrollment(int id)
        //{
        //    var enrollment = await _context.Enrollment.FindAsync(id);
        //    _context.Enrollment.Remove(enrollment);
        //    _context.SaveChanges();
        //}

        //public async Task UpdateEnrollment(int id, Enrollment enrollment)
        //{
        //    _context.Entry(enrollment).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}
    }
}
