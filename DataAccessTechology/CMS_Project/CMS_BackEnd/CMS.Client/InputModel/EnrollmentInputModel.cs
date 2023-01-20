using System.ComponentModel.DataAnnotations;

namespace CMS.Client.InputModel
{
    public class EnrollmentInputModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        //public string StudentName { get; set; }
        //public string CourseName { get; set; }
        //public DateTime EnrollmentDate { get; set; }
    }
}
