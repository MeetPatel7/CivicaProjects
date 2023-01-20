using AutoFixture;
using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EMS.UnitTesting
{
    public class DepartmentUnitTest : ApiUnitTestBase<DepartmentController>
    {
        private Mock<IDepartmentRepository> mockDepartmentRepository;
        public override void TestSetup()
        {
            mockDepartmentRepository = this.CreateAndInjectMock<IDepartmentRepository>();
            Target = new DepartmentController(mockDepartmentRepository.Object);
        }

        public override void TestTearDown()
        {
            mockDepartmentRepository.VerifyAll();
        }

        [Fact]

        public void GetAllDepartment_Return_Ok()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            //arrange

            IEnumerable<Department> department = fixture.CreateMany<Department>();
            Task<IEnumerable<Department>> departmentTask = Task.FromResult(department);
            this.mockDepartmentRepository.Setup(c => c.GetAllDepartments()).Returns(departmentTask);

            //act

            var actual = Target.GetAllDepartments();
            var act = Target.GetAllDepartments().Result;
            var result = act.Result as OkObjectResult;

            //assert

            Assert.NotNull(actual);
            Assert.Equal(departmentTask.Result, result.Value);
        }

        [Fact]
        public void GetAllDepartment_Return_NotFound()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            //arrange

            IEnumerable<Department> department = null;
            Task<IEnumerable<Department>> departmentTask = Task.FromResult(department);
            this.mockDepartmentRepository.Setup(c => c.GetAllDepartments()).Returns(departmentTask);

            //act

            var actual = Target.GetAllDepartments();
            var act = actual.Result;
            var result = act.Result as StatusCodeResult;

            //assert

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            this.mockDepartmentRepository.Verify(c => c.GetAllDepartments(), Times.Once);
        }

        [Fact]
        public void GetDepartmentById_Return_Ok()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange
            var id = Fixture.Create<int>();
            var department = fixture.Create<Department>();
            Task<Department> departmentTask = Task.FromResult(department);
            this.mockDepartmentRepository.Setup(c => c.GetDepartmentById(id)).Returns((departmentTask));

            // act
            var actual = Target.GetDepartmentById(id);
            var act = Target.GetDepartmentById(id).Result;
            var result = act.Result as OkObjectResult;

            // assert
            Assert.NotNull(actual);
            Assert.Equal(departmentTask.Result, result.Value);
        }

        [Fact]
        public void GetEmployeeById_Return_NotFound()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var id = Fixture.Create<int>();
            Department department = null;
            Task<Department> departmentTask = Task.FromResult(department);
            this.mockDepartmentRepository.Setup(c => c.GetDepartmentById(id)).Returns(departmentTask);

            // act

            var actual = Target.GetDepartmentById(id);
            var act = actual.Result;
            var result = act.Result as StatusCodeResult;

            // assert

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void AddDepartment_Return_BadRequest()
        {
            // arrange

            Department department = null;

            // act
   
            var actual = Target.AddDepartment(department);
            var act = actual.Result;
            var result = act.Result as StatusCodeResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void AddDepartment_Return_CreatedAtAction()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var department = fixture.Create<Department>();
            this.mockDepartmentRepository.Setup(c => c.AddDepartment(department)).Returns(Task.CompletedTask);

            // act

            var actual = Target.AddDepartment(department);
            var act = actual.Result;
            var result = act.Result as CreatedAtActionResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
            this.mockDepartmentRepository.Verify(c => c.AddDepartment(department), Times.Once);
        }

        [Fact]
        public void DeleteDepartment_Return_Ok()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var id = fixture.Create<int>();
            var department = fixture.Create<Department>();
            department.Id = id;
            Task<Department> department1 = Task.FromResult(department);
            this.mockDepartmentRepository.Setup(c => c.DeleteDepartment(id)).Returns(department1);

            // act

            var actual = Target.DeleteDepartment(id);
            var act = actual.Result;
            var result = act as StatusCodeResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
