using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class EmpController : ApiController
    {
        List<Emp> emp = new List<Emp>
        {
            new Emp
            {
                Id=1,
                FirstName="Harsh",
                MiddleName="R",
                LastName="Darji",
                Gerder="Male",
                Salary=20000.00
            },

            new Emp
            {
                Id=2,
                FirstName="Khushal",
                MiddleName="J",
                LastName="Rana",
                Gerder="Male",
                Salary=25000.00
            },

            new Emp
            {
                Id=3,
                FirstName="Hard",
                MiddleName="P",
                LastName="Parikh",
                Gerder="Male",
                Salary=30000.00
            }
        };



        // GET api/values
        [HttpGet]
        public IEnumerable<Emp> GetEmp()
        {
            return emp.ToList();
        }

        // GET api/values
        [HttpGet]
        public Emp GetEmp(int id)
        {
            return emp.Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IEnumerable<Emp> Post([FromBody] Emp emp1)
        {
            if (emp1 == null)
            {
                throw new ArgumentNullException();
            }
            emp.Add(emp1);
            return emp;
        }

        [HttpPut]
        public Emp Put(int id, [FromBody] Emp emp1)
        {
            if (emp1 == null)
            {
                throw new ArgumentNullException();
            }
            Emp emp2 = emp.FirstOrDefault(e => e.Id == id);
            emp2.FirstName = emp1.FirstName;
            emp2.MiddleName = emp1.MiddleName;
            emp2.LastName = emp1.LastName;
            emp2.Gerder = emp1.Gerder;
            emp2.Salary = emp1.Salary;
            return emp2;
        }

        [HttpDelete]
        public IEnumerable<Emp> Delete(int id)
        {
            emp.RemoveRange(0, id);
            return emp;
        }
    }
}