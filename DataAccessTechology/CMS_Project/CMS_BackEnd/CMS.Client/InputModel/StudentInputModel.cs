using CMS.Business.Entity;
using System.ComponentModel.DataAnnotations;

namespace CMS.Client.InputModel
{
    public class StudentInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public int CourseCout { get; set; }

        //public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
