using DatabaseFirstApproachEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        EFDatabaseFirstApproachDBEntities db = new EFDatabaseFirstApproachDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            

            if(ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted !!')</script>";
                }   
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!')</script>";
                }
            }
            
            return View();
        }

        public ActionResult Delete(int id)
        {
            if(id>0)
            {
                var DeleteRow = db.Students.Where(model => model.Id == id).FirstOrDefault();
                if(DeleteRow != null)
                {
                    db.Entry(DeleteRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Not Dele ted !!')</script>";
                    }
                }
            }
            return View();

        }

        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        //[HttpPost]
        //public ActionResult Delete(Student s)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        db.Entry(s).State = EntityState.Deleted;
        //        int a = db.SaveChanges();

        //        if (a > 0)
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Not Dele ted !!')</script>";
        //        }
        //    }

        //    return View();
        //}
    }
}