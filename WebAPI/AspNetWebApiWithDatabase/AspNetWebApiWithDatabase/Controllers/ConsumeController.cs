using AspNetWebApiWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebApiWithDatabase.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume

        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Student> list = new List<Student>();
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response  = client.GetAsync("StudentApi");
            response .Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.PostAsJsonAsync<Student>("StudentApi",s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.GetAsync("StudentApi?Id="+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.GetAsync("StudentApi?Id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.PutAsJsonAsync<Student>("StudentApi", s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Delete(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.GetAsync("StudentApi?Id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44306/api/StudentApi");
            var response = client.DeleteAsync("StudentApi/ " + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}