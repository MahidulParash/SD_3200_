using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SD_3200_.Models;
using System.Net;
using System.Data.SqlClient;
using System.Globalization;

namespace SD_3200_.Controllers
{
    public class loginController : Controller
    {
        HttpCookie kt1, kt2;
        private elearningEntities4 db = new elearningEntities4();
        // GET: login
        public ActionResult studentDashboard()
        {
            string actionName = "studentDashboard";
            string controllerName = "login";
            kt1 = new HttpCookie("studentAction", actionName);
            kt2 = new HttpCookie("studentController", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            
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
            string actionName = "studentDashboard";
            string controllerName = "login";
            kt1 = new HttpCookie("studentAction", actionName);
            kt2 = new HttpCookie("studentController", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            ViewBag.id = id;
            var lessons = db.lessons.Where(c => c.course_ID == id);
            return View(lessons.ToList());
        }
        public ActionResult WatchVideo(int id)
        {
            
            ViewBag.id = id;// Convert.ToInt32(Request.Cookies["lessonid"].Value);
            string stdactionName = "studentDashboard";
            string stdcontrollerName = "login";
            kt1 = new HttpCookie("studentAction", stdactionName);
            kt2 = new HttpCookie("studentController", stdcontrollerName);
            
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            
            var lesson = db.lessons.Where(c => c.lesson_ID == id).FirstOrDefault();
            ViewBag.link = Convert.ToString(lesson.lesson_link);
            ViewBag.name= Convert.ToString(lesson.lesson_name);
            ViewBag.desc = Convert.ToString(lesson.lesson_desc);
            return View();
        }
        public ActionResult studentProfile()
        {
            string stdactionName = "studentProfile";
            string stdcontrollerName = "login";
            kt1 = new HttpCookie("studentAction", stdactionName);
            kt2 = new HttpCookie("studentController", stdcontrollerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            return View();
        }
        public ActionResult ContactUs()
        {
            string actionName = "ContactUs";
            string controllerName = "login";
            kt1 = new HttpCookie("studentAction", actionName);
            kt2 = new HttpCookie("studentController", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            ViewBag.email = Session["userEmail"];
            ViewBag.id = Session["userID"];
            return View();
        }
        public ActionResult addFeedback(string studentID,string feedback)
        {
            ViewBag.email = Session["userEmail"];
            int id = Convert.ToInt32(studentID);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();


            sql = new SqlCommand("insert into feedback(student_id,feedback_text) values('" + id + "','"+feedback+"');", con);
            sql.ExecuteNonQuery();
            con.Close();
            return View("ContactUs");
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session["userEmail"] = null;
           
            
            return RedirectToAction("HomePage", "Home");
        }
        
    }
}