using SD_3200_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SD_3200_.Controllers
{
    public class HomeController : Controller
    {
        elearningEntities2 db = new elearningEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Courses()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPage([Bind(Include = "studentName, studentEmail, studentPass")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return View();

            }
            return View();
        }

    }
}