using System.ComponentModel.DataAnnotations;

namespace CMS.Client.InputModel
{
    public class EnrollmentInputModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
