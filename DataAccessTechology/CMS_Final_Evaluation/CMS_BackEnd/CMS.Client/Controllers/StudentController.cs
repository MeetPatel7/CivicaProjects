using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _student;

        public StudentController(IStudentRepository student)
        {
            _student = student;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudent()
        {
            try
            {
                IEnumerable<Student> studentData = await _student.GetStudent();

                if (studentData == null)
                {
                    return NotFound();
                }
                IEnumerable<StudentViewModel> studentViewModel = ConvertDbModelToViewModel(studentData);
                return Ok(studentViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<ActionResult<StudentViewModel>> GetStudentById(int id)
        {
            try
            {
                var studentDataById = await _student.GetStudentById(id);

                if (studentDataById == null)
                {
                    return NotFound();
                }
                StudentViewModel studentViewModels = ConvertDbModelToViewModel(studentDataById);
                return Ok(studentViewModels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("not/{id}")]
        public async Task<ActionResult<Student>> GetStudentNotEnrollCourse(int id)
        {
            try

            {
                var getStudentById = await _student.GetStudentNotEnrollCourse(id);

                if (getStudentById == null)
                {
                    return NotFound();
                }
                return Ok(getStudentById);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var student = await _student.GetStudentNotEnrollCourse(id);
                if (student == null)
                {
                    await _student.DeleteStudent(id);
                    return NoContent();
                }
                return BadRequest();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private static IEnumerable<StudentViewModel> ConvertDbModelToViewModel(IEnumerable<Student> student)
        {
            ICollection<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            foreach (var data in student)
            {
                studentViewModels.Add(new StudentViewModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    DateOfBirth = data.DateOfBirth
                });
            }
            return studentViewModels;
        }

        private static StudentViewModel ConvertDbModelToViewModel(Student student)
        {
            StudentViewModel studentViewModel = new StudentViewModel();

            studentViewModel.Id = student.Id;
            studentViewModel.FirstName = student.FirstName;
            studentViewModel.LastName = student.LastName;
            studentViewModel.Email = student.Email;
            studentViewModel.DateOfBirth = student.DateOfBirth;

            return studentViewModel;
        }
    }
}