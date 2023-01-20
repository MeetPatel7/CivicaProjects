using AspNetWebApiWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AspNetWebApiWithDatabase.Controllers
{
    public class StudentApiController : ApiController
    {
        EFDatabaseFirstApproachDBEntities db = new EFDatabaseFirstApproachDBEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Action()
        {
            List<Student> obj = db.Students.ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetDetailById(int id)
        {
            var obj = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return Ok(obj);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult StudentCreate(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult StudentUpdate(Student s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            /*var obj = db.Students.Where(model => model.Id == s.Id).FirstOrDefault();

            if(obj != null)
            {
                obj.Name = s.Name;
                obj.Gender = s.Gender;  
                obj.Age = s.Age;    
                obj.Standard = s.Standard;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }*/
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult StudentDelete(int id)
        {
            var studentId = db.Students.Where(model => model.Id == id).FirstOrDefault();
            db.Entry(studentId).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
