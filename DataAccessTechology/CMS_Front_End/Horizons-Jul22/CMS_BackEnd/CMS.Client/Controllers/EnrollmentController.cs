using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Client.InputModel;
using CMS.Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollment;

        public EnrollmentController(IEnrollmentRepository enrollment)
        {
            _enrollment = enrollment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentViewModel>>> GetEnrollment()
        {
            try
            {
                IEnumerable<Enrollment> enrollmentData = await _enrollment.GetEnrollment();

                if (enrollmentData == null)
                {
                    return NotFound();
                }
                IEnumerable<EnrollmentViewModel> enrollmentViewModel = ConvertDbModelToViewModel(enrollmentData);
                return Ok(enrollmentViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}" , Name = "GetEnrollmentById")]
        public async Task<ActionResult<EnrollmentViewModel>> GetEnrollmentById(int id)
        {
            try
            {
                var enrollmentDataById = await _enrollment.GetEnrollmentById(id);

                if (enrollmentDataById == null)
                {
                    return NotFound();
                }
                EnrollmentViewModel enrollmentViewModels = ConvertDbModelToViewModel(enrollmentDataById);
                return Ok(enrollmentViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment([FromForm] EnrollmentInputModel enrollmentInputModel)
        {
            try
            {
                if (enrollmentInputModel != null)
                {
                    Enrollment enrollment = ConvertInputModeltoDbModel(enrollmentInputModel);

                    await _enrollment.AddEnrollment(enrollment);

                    await GetEnrollmentById(enrollment.Id);

                    return CreatedAtRoute("GetEnrollmentById", new { id = enrollment.Id }, enrollment);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private static IEnumerable<EnrollmentViewModel> ConvertDbModelToViewModel(IEnumerable<Enrollment> enrollment)
        {
            ICollection<EnrollmentViewModel> enrollmentViewModels = new List<EnrollmentViewModel>();
            foreach (var data in enrollment)
            {
                enrollmentViewModels.Add(new EnrollmentViewModel
                {
                    Id = data.Id,
                    StudentId = data.StudentId,
                    CourseId = data.CourseId,
                    EnrollmentDate = data.EnrollmentDate
                });
            }
            return enrollmentViewModels;
        }

        private static EnrollmentViewModel ConvertDbModelToViewModel(Enrollment enrollment)
        {
            EnrollmentViewModel enrollmentViewModel = new EnrollmentViewModel();

            enrollmentViewModel.Id = enrollment.Id;
            enrollmentViewModel.StudentId = enrollment.StudentId;
            enrollmentViewModel.CourseId = enrollment.CourseId;
            enrollmentViewModel.EnrollmentDate = enrollment.EnrollmentDate;

            return enrollmentViewModel;
        }

        private static Enrollment ConvertInputModeltoDbModel(EnrollmentInputModel inputModel)
        {
            Enrollment enrollment = new()
            {
                StudentId = inputModel.StudentId,
                CourseId = inputModel.CourseId,
                EnrollmentDate = inputModel.EnrollmentDate
            };
            return enrollment;
        }
    }
}
