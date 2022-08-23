using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SD_3200_.Models;
using System.Net;
using System.Data.SqlClient;

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
        public ActionResult approve(string Approved)
        {
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
            var students = db.students;
            return View(students.ToList());
        }
        public ActionResult editStudent(string editStudent)
        {
            
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
    }
}