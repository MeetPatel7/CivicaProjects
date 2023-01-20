using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkFirstDemo.Models;
using System.Collections;

namespace EntityFrameworkFirstDemo.Controllers
{
    public class HomeController : Controller
    {
        StudentContext scdb = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = scdb.Students.ToList();
            return View(data);
        }
    }
}