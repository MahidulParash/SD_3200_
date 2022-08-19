using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Web.Mvc;
using SD_3200_.Models;
using System.Net;

namespace SD_3200_.Controllers
{
    public class loginController : Controller
    {
        private elearningEntities4 db = new elearningEntities4();
        // GET: login
        public ActionResult studentDashboard()
        {
            int i = Convert.ToInt32(Session["userID"]);
            string str = "paid";
            var courses = db.enrolls.Where(c=>c.student_ID==i&&c.paymentStatus==str);
            if (Session["userRole"] == "student")
            {
                return View(courses.ToList());
            }
            else
            {
                return RedirectToAction("instructorDashboard", "Admin");
            }
            
        }
        public ActionResult SelectedCourse(int id)
        {
            ViewBag.id = id;
            var lessons = db.lessons.Where(c => c.course_ID == id);
            return View(lessons.ToList());
        }
        public ActionResult WatchVideo(int id)
        {
            ViewBag.id = id;
            var lessons = db.lessons.Where(c => c.course_ID == id);
            return View();
        }
        public ActionResult studentProfile()
        {
            return View();
        }
        
        public ActionResult logout()
        {
            Session.Abandon();
            Session["userEmail"] = null;
        
            return RedirectToAction("HomePage", "Home");
        }
        
    }
}