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
    public class AdminController : Controller
    {
        HttpCookie kt1,kt2;
        private elearningEntities4 db = new elearningEntities4();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult instructorDashboard()
        {
            string actionName = "instructorDashboard";
            string controllerName = "Admin";
            kt1 = new HttpCookie("action", actionName);
            kt2 = new HttpCookie("controller", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            //SELECT COUNT(ProductID)
           // FROM Products;

            sql = new SqlCommand("SELECT COUNT(course_ID) FROM courses;", con);
            int coursecount= (Int32)sql.ExecuteScalar(); ;
            ViewBag.courseCount = coursecount;

            sql = new SqlCommand("SELECT COUNT(enroll_ID) FROM enroll;", con);
            int enrollcount = (Int32)sql.ExecuteScalar(); ;
            ViewBag.enrollCount = enrollcount;

            DateTime dt = DateTime.Now;
            string date_string = dt.ToString("yyyy-MM-dd");
  
            sql = new SqlCommand("SELECT COUNT(enroll_ID) FROM enroll WHERE enroll_date = '" + date_string + "';", con);
            int enrolltodaycount = (Int32)sql.ExecuteScalar(); ;
            ViewBag.enrolltodayCount = enrolltodaycount;

            
            sql = new SqlCommand("SELECT COUNT(studentID) FROM student;", con);
            int studentcount = (Int32)sql.ExecuteScalar(); ;
            ViewBag.studentCount = studentcount;

            con.Close();
            return View();
        }
        public ActionResult approveCourse()
        {
            string actionName = "approveCourse";
            string controllerName = "Admin";
            kt1 = new HttpCookie("action", actionName);
            kt2 = new HttpCookie("controller", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            string str = "unpaid";
            var courses = db.enrolls.Where(c => c.paymentStatus == str);
            return View(courses.ToList());
        }
        public ActionResult approve(string Approved)
        {
            string actionName = "approve";
            string controllerName = "Admin";
            kt1 = new HttpCookie("action", actionName);
            kt2 = new HttpCookie("controller", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            int id = Convert.ToInt32(Approved);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();

            
            sql = new SqlCommand("UPDATE enroll SET paymentStatus = 'paid' WHERE enroll_ID = "+id+";",con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("approveCourse");
        }
        public ActionResult AdminStudents()
        {
            string actionName = "AdminStudents";
            string controllerName = "Admin";
            kt1 = new HttpCookie("action", actionName);
            kt2 = new HttpCookie("controller", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            var students = db.students;
            return View(students.ToList());
        }
        public ActionResult editStudent(string editStudent)
        {
            int id = Convert.ToInt32(editStudent);
            var student = db.students.Where(c => c.studentID == id).FirstOrDefault();
            ViewBag.studentID = student.studentID;
            ViewBag.studentEmail = student.studentEmail;
            ViewBag.studentName = student.studentName;
            ViewBag.studentPassword = student.studentPass;
            return View();
        }
        public ActionResult deleteStudent(string deleteStudent)
        {
            int id = Convert.ToInt32(deleteStudent);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("DELETE FROM enroll WHERE student_ID = " + id + ";", con);
            sql.ExecuteNonQuery();

            sql = new SqlCommand("DELETE FROM student WHERE studentID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminStudents");
        }
        public ActionResult adminEditStudent(string adminStudentEdit,string studentName, string studentEmail,string studentPassword)
        {
            int id = Convert.ToInt32(adminStudentEdit);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("UPDATE student SET studentName = '" + studentName + "' WHERE studentID = " + id + ";", con);
            sql.ExecuteNonQuery();

            sql = new SqlCommand("UPDATE student SET studentPass = '" + studentPassword + "' WHERE studentID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminStudents");
        }
        public ActionResult AdminProfile()
        {
            int id = Convert.ToInt32(Session["userID"]);
            var instructor = db.instructors.Where(c => c.instructor_ID == id).FirstOrDefault();
            ViewBag.instructorID = instructor.instructor_ID;
            ViewBag.instructorEmail = instructor.instructor_email;
            ViewBag.instructorName = instructor.instructor_name;
            ViewBag.instructorPassword = instructor.instructor_password;
            
            return View();
        }
        public ActionResult editinstructorProfile(string instructorProfile, string instructorName, string instructorPassword)
        {
            int id = Convert.ToInt32(instructorProfile);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("UPDATE instructor SET instructor_name = '" + instructorName + "' WHERE instructor_ID = " + id + ";", con);
            sql.ExecuteNonQuery();

            sql = new SqlCommand("UPDATE instructor SET instructor_password = '" + instructorPassword + "' WHERE instructor_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminProfile");
        }
    }

}