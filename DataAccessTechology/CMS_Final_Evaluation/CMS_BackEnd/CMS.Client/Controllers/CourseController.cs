using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _course;

        public CourseController(ICourseRepository course)
        {
            _course = course;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourse()
        {
            try
            {
                IEnumerable<Course> courseData = await _course.GetCourse();

                if (courseData == null)
                {
                    return NotFound();
                }
                IEnumerable<CourseViewModel> courseViewModel = ConvertDbModelToViewModel(courseData);
                return Ok(courseViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseViewModel>> GetCourseById(int id)
        {
            try
            {
                var courseDataById = await _course.GetCourseById(id);

                if (courseDataById == null)
                {
                    return NotFound();
                }
                CourseViewModel courseViewModels = ConvertDbModelToViewModel(courseDataById);
                return Ok(courseViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        private static IEnumerable<CourseViewModel> ConvertDbModelToViewModel(IEnumerable<Course> course)
        {
            ICollection<CourseViewModel> courseViewModels = new List<CourseViewModel>();
            foreach (var data in course)
            {
                courseViewModels.Add(new CourseViewModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    IsActive = data.IsActive
                });
            }
            return courseViewModels;
        }
        private static CourseViewModel ConvertDbModelToViewModel(Course course)
        {
            CourseViewModel courseViewModel = new CourseViewModel();

            courseViewModel.Id = course.Id;
            courseViewModel.Name = course.Name;
            courseViewModel.Description = course.Description;
            courseViewModel.IsActive = course.IsActive;
            
            return courseViewModel;
        }
    }
}
