using CMS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Abstraction
{
    public interface IEnrollmentRepository
    {
        public Task<IEnumerable<Enrollment>> GetEnrollment();
        public Task<Enrollment> GetEnrollmentById(int id);
        public Task AddEnrollment(Enrollment enrollment);
        public int GetStudentEnrollCourseCount(int id);
        public int GetEnrollCourseCount(int sid,int cid);
    }
}
