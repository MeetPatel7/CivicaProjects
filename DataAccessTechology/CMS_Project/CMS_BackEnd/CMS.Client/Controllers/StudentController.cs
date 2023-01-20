using CMS.Business.Abstraction;
using CMS.Business.Entity;
using CMS.Client.InputModel;
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

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentInputModel studentInputModel)
        {
            try
            {
                if (studentInputModel != null)
                {
                    Student student = ConvertInputModeltoDbModel(studentInputModel);

                    await _student.AddStudent(student);

                    await GetStudentById(student.Id);

                    return CreatedAtRoute("GetStudentById", new { id = student.Id }, student);
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

        //public async Task<ActionResult<Student>> AddStudent(Student student)
        //{
        //    try
        //    {
        //        if (student == null)
        //        {
        //            return BadRequest();
        //        }
        //        await _student.AddStudent(student);
        //        return CreatedAtAction("GetStudent", new { id = student.Id }, student);

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpGet("not/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
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
                var student = _student.GetStudentNotEnrollCoursecount(id);
                if (student == 0)
                {
                    await _student.DeleteStudent(id);
                    return NoContent();
                }
                return BadRequest();


                //var student = await _student.GetStudentNotEnrollCourse(id);
                //if (student == null)
                //{
                //    await _student.DeleteStudent(id);
                //    return NoContent();
                //}
                //return BadRequest();

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

        private static Student ConvertInputModeltoDbModel(StudentInputModel inputModel)
        {
            Student student = new()
            {
                FirstName = inputModel.FirstName,
                LastName=inputModel.LastName,
                Email=inputModel.Email,
                DateOfBirth=inputModel.DateOfBirth ,
                //Enrollment = inputModel.Enrollment,
            };
            return student;
        }
    }
}