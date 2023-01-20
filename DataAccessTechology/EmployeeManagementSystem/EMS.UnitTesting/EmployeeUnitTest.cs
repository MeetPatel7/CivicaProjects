using AutoFixture;
using EMS.Business.Abstraction;
using EMS.Business.Entities;
using EMS.Client.Controllers;
using EMS.Data.Repository;
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
    public class EmployeeUnitTest: ApiUnitTestBase<EmployeeController>
    {
        private Mock<IEmployeeRepository> mockEmployeeRepository;

        public override void TestSetup()
        {
            mockEmployeeRepository = this.CreateAndInjectMock<IEmployeeRepository>();
            Target = new EmployeeController(mockEmployeeRepository.Object);
        }

        public override void TestTearDown()
        {
            mockEmployeeRepository.VerifyAll();
        }

        [Fact]

        public void GetAllEmployees_Return_Ok()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            IEnumerable<Employee> employees = fixture.CreateMany<Employee>();
            Task<IEnumerable<Employee>> employeesTask = Task.FromResult(employees);
            this.mockEmployeeRepository.Setup(c => c.GetAllEmployees()).Returns(employeesTask);

            // act

            var actual = Target.GetAllEmployees();
            var act = Target.GetAllEmployees().Result;
            var result = act.Result as OkObjectResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal(employeesTask.Result, result.Value);
        }

        [Fact]
        public void GetAllEmployees_Return_NotFound()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            IEnumerable<Employee> employee = null;
            Task<IEnumerable<Employee>> taskEmployee = Task.FromResult(employee);
            this.mockEmployeeRepository.Setup(c => c.GetAllEmployees()).Returns(taskEmployee);

            // act

            var actual = Target.GetAllEmployees();
            Task<ActionResult<Employee>> e = actual;
            var actualResult = e.Result;
            var temp = actualResult.Result as StatusCodeResult;

            // assert

            Assert.NotNull(temp);
            Assert.Equal((int)HttpStatusCode.NotFound, temp.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.GetAllEmployees(), Times.Once);
        }

        [Fact]
        public void GetEmployeeById_Return_Ok()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var id = Fixture.Create<int>();
            var employees = fixture.Create<Employee>();
            Task<Employee> employeesTask = Task.FromResult(employees);
            this.mockEmployeeRepository.Setup(c => c.GetEmployeeById(id)).Returns(employeesTask);

            // act

            var actual = Target.GetEmployeeById(id);
            var act = Target.GetEmployeeById(id).Result;
            var result = act.Result as OkObjectResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal(employeesTask.Result, result.Value);
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
            Employee employees = null;
            Task<Employee> employeesTask = Task.FromResult(employees);
            this.mockEmployeeRepository.Setup(c => c.GetEmployeeById(id)).Returns((employeesTask));

            // act

            var actual = Target.GetEmployeeById(id);
            var act = actual.Result;
            var result = act.Result as StatusCodeResult;

            // assert

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void AddEmployee_Return_CreatedAtAction()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            //arrange

            var employees = fixture.Create<Employee>();
            this.mockEmployeeRepository.Setup(c => c.AddEmployee(employees)).Returns(Task.CompletedTask);

            // act

            var actual = Target.AddEmployee(employees);
            var act = actual.Result;
            var result = act.Result as CreatedAtActionResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.AddEmployee(employees), Times.Once);
        }

        [Fact]
        public void AddEmployee_Return_BadRequest()
        {

            // arrange

            Employee employees = null;

            // act
          
            var actual = Target.AddEmployee(employees);
            var act = actual.Result;
            var result = act.Result as StatusCodeResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void UpdateEmployee_Return_OK()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var id = fixture.Create<int>();
            var employee = fixture.Create<Employee>();
            employee.Id = id;
            Task<Employee> employeesTask = Task.FromResult(employee);
            this.mockEmployeeRepository.Setup(c => c.UpdateEmployee(employee)).Returns(Task.CompletedTask);

            // act

            var actual = Target.UpdateEmployee(id, employee);
            var result = actual.Result as StatusCodeResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            mockEmployeeRepository.Verify(c => c.UpdateEmployee(employee), Times.Once);
        }

        [Fact]
        public void UpdateEmployee_Return_BadRequest()
        {
            var fixture = new Fixture();
            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            // arrange

            var id = fixture.Create<int>();
            Employee employee = null;

            // act

            var actual = Target.UpdateEmployee(id, employee);
            var result = actual.Result as StatusCodeResult;

            // assert

            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);


        }
    }
}
