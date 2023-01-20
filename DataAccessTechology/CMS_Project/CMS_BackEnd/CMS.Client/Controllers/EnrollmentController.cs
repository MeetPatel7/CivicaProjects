using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Business.Exception;
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
        private readonly ICourseRepository _course;

        public EnrollmentController(IEnrollmentRepository enrollment, ICourseRepository course)
        {
            _enrollment = enrollment;
            _course = course;
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

        [HttpGet("{id}/CourseCount")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<Student>> GetStudentEnrollCourseCount(int id)
        {
            try
            {
                var getStudentCourse = _enrollment.GetStudentEnrollCourseCount(id);

                if (getStudentCourse == 0)
                {
                    return Ok(getStudentCourse);
                }
                return Ok(getStudentCourse);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{sid}/CourseMatch/{cid}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<Student>> GetEnrollCourseCount(int sid,int cid)
        {
            try
            {
                var getStudentCoursematch = _enrollment.GetEnrollCourseCount(sid,cid);

                if (getStudentCoursematch == 0)
                {
                    return Ok(getStudentCoursematch);
                }
                return Ok(getStudentCoursematch);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(EnrollmentInputModel enrollmentInputModel)
        {
            try
            {
                if (enrollmentInputModel != null)
                {
                    var courseCount = _enrollment.GetStudentEnrollCourseCount(enrollmentInputModel.StudentId);

                    if(courseCount < 3)
                    {
                        var singleCourse = _enrollment.GetEnrollCourseCount(enrollmentInputModel.StudentId,enrollmentInputModel.CourseId);

                        var courseDetails = _course.GetCourseById(enrollmentInputModel.CourseId);
                         
                        if (singleCourse == 0)
                        {
                            Enrollment enrollment = ConvertInputModeltoDbModel(enrollmentInputModel);

                            await _enrollment.AddEnrollment(enrollment);

                            await GetEnrollmentById(enrollment.Id);

                            return CreatedAtRoute("GetEnrollmentById", new { id = enrollment.Id }, enrollment);
                        }
                        //return BadRequest();
                        else
                        {
                            throw new AlreadyEnrollException(courseDetails.Result.Name);
                        }
                    }
                    else
                    {
                        throw new EnrollmentLimitReachedException();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (EnrollmentLimitReachedException elex)
            {
                return StatusCode(400,elex.Message);
            }
            catch(AlreadyEnrollException aeex)
            {
                return StatusCode(400,aeex.Message);
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
                //EnrollmentDate = inputModel.EnrollmentDate
            };
            return enrollment;
        }
    }
}
