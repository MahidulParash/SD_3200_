using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SD_3200_.Models;
using System.Net;

namespace SD_3200_.Controllers
{
    public class AdminController : Controller
    {
        private elearningEntities4 db = new elearningEntities4();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult instructorDashboard()
        {
            return View();
        }
        public ActionResult approveCourse()
        {
            
            string str = "unpaid";
            var courses = db.enrolls.Where(c => c.paymentStatus == str);
            return View(courses.ToList());
        }
    }
}