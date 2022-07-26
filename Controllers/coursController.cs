﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SD_3200_.Models;

namespace SD_3200_.Controllers
{
    public class coursController : Controller
    {
        HttpCookie kt1, kt2;
        private elearningEntities4 db = new elearningEntities4();

        // GET: cours
        public ActionResult Index()
        {
            string actionName = "Index";
            string controllerName = "cours";
            kt1 = new HttpCookie("studentAction", actionName);
            kt2 = new HttpCookie("studentController", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            var courses = db.courses;
            return View(courses.ToList());
        }

        public ActionResult AdminCourses()
        {
            string actionName = "AdminCourses";
            string controllerName = "cours";
            kt1 = new HttpCookie("action", actionName);
            kt2 = new HttpCookie("controller", controllerName);
            Response.Cookies.Add(kt1);
            Response.Cookies.Add(kt2);
            var courses = db.courses.Include(c => c.instructor);
            return View(courses.ToList());
        }


        //// GET: cours/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    cours cours = db.courses.Find(id);
        //    if (cours == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cours);
        //}

        // GET: cours/Create
        public ActionResult Create()
        {
            ViewBag.instructor_ID = new SelectList(db.instructors, "instructor_ID", "instructor_name");
            return View();
        }

        // POST: cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "course_ID,instructor_ID,course_name,course_desc,course_image,course_duration,course_price")] cours cours)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(cours);
                db.SaveChanges();
                return RedirectToAction("AdminCourses");
            }

            ViewBag.instructor_ID = new SelectList(db.instructors, "instructor_ID", "instructor_name", cours.instructor_ID);
            return View(cours);
        }

        //public ActionResult Edit(string Edit)
        //{
        //    var id = Convert.ToInt32(Edit);
        //    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
        //    SqlCommand sql;
        //    con.Open();

        //    if (ModelState.IsValid)
        //    {
        //        sql = new SqlCommand("UPDATE enroll SET paymentStatus = 'paid' WHERE enroll_ID = " + id + ";", con);
        //        sql.ExecuteNonQuery();
        //        con.Close();
        //        return RedirectToAction("approveCourse");
        //    }



        //    return View();
        //}
        //// GET: cours/Edit/5
        ///*public ActionResult Edit(string Edit)
        //{
        //    var id = Convert.ToInt32(Edit);
        //    /*if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    cours cours = db.courses.Find(id);
        //    if (cours == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.instructor_ID = new SelectList(db.instructors, "instructor_ID", "instructor_name", cours.instructor_ID);
        //    return View(cours);
        //}

        // POST: cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "course_ID,instructor_ID,course_name,course_desc,course_image,course_duration,course_price")] cours cours)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cours).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.instructor_ID = new SelectList(db.instructors, "instructor_ID", "instructor_name", cours.instructor_ID);
        //    return View(cours);
        //}*/

        //GET: cours/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    cours cours = db.courses.Find(id);
        //    if (cours == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cours);
        //}

        // POST: cours/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    cours cours = db.courses.Find(id);
        //    db.courses.Remove(cours);
        //    db.SaveChanges();
        //    return RedirectToAction("AdminCourses");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Details(string coursedit)
        {
            var id = Convert.ToInt32(coursedit);
            var courses = db.courses.Where(c => c.course_ID == id);
            return View(courses.ToList());
        }

        public ActionResult CoursePage(string course_ID)
        {
            var id = Convert.ToInt32(course_ID);
            int student_ID = Convert.ToInt32(Session["userID"]);
            var enrollDetails = db.enrolls.Where(x => x.course_ID == id && x.student_ID == student_ID).FirstOrDefault();
            if(enrollDetails==null)
            {
                ViewBag.flag = 1;
            }    
            else
            {
                ViewBag.flag = 0;
            }
            var courses = db.courses.Where(c => c.course_ID == id);
            return View(courses.ToList());
        }

        public ActionResult Edit(string editCourse)
        {
            int id = Convert.ToInt32(editCourse);
            var course = db.courses.Where(c => c.course_ID == id).FirstOrDefault();
            ViewBag.course_ID = course.course_ID;
            ViewBag.course_name = course.course_name;
            ViewBag.course_desc = course.course_desc;
            ViewBag.course_img = course.course_image;
            ViewBag.course_duration = course.course_duration;
            ViewBag.course_price = course.course_price;
            return View();
        }
        public ActionResult adminEditCourse(string editCourse, string course_name, string course_desc, string course_image, string course_duration, string course_price)
        {
            int id = Convert.ToInt32(editCourse);
            int intCourseDuration = Convert.ToInt32(course_duration);
            double intCoursePrice = Convert.ToDouble(course_price);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("UPDATE courses SET course_name = '" + course_name + "' WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();

            sql = new SqlCommand("UPDATE courses SET course_desc = '" + course_desc + "' WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            sql = new SqlCommand("UPDATE courses SET course_image = '" + course_image + "' WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            sql = new SqlCommand("UPDATE courses SET course_duration = '" + intCourseDuration + "' WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            sql = new SqlCommand("UPDATE courses SET course_price = '" + intCoursePrice + "' WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();

            con.Close();
            return RedirectToAction("AdminCourses");
        }
        public ActionResult DeleteCourse(string course_ID)
        {
            int id = Convert.ToInt32(course_ID);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True"); //LAPTOP-AIC623KV
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("DELETE FROM courses WHERE course_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminCourses");
        }
        public ActionResult Enroll(string course_ID)
        {
            DateTime dt = DateTime.Now;
            string date_string = dt.ToString("yyyy-MM-dd");
            int student_ID = Convert.ToInt32(Session["userID"]);
            int id = Convert.ToInt32(course_ID);
            //var enrollDetails = db.enrolls.Where(x => x.course_ID == id && x.student_ID == student_ID).FirstOrDefault();
            var course = db.courses.Where(c => c.course_ID == id).FirstOrDefault();
            if (course != null)
            {
                ViewBag.course_ID = course_ID;
                ViewBag.course_name = course.course_name;
                ViewBag.course_desc = course.course_desc;
                ViewBag.course_img = course.course_image;
                ViewBag.course_duration = course.course_duration;
                ViewBag.course_price = course.course_price;
                ViewBag.userEmail = Session["userEmail"];
                ViewBag.userName = Session["userName"];
                ViewBag.userID = Session["userID"];
                ViewBag.date = date_string;
            }
            return View();
        }
        public ActionResult EnrollCourse(string course_ID,string transactionID)
        {
            DateTime dt = DateTime.Now;
            string date_string = dt.ToString("yyyy-MM-dd");
            int id = Convert.ToInt32(course_ID);
            int student_ID = Convert.ToInt32(Session["userID"]);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True"); //LAPTOP-AIC623KV
            SqlCommand sql;
            con.Open();

            sql = new SqlCommand("INSERT INTO enroll(course_ID, student_ID, enroll_date,transactionID) Values(" + id + "," + student_ID + ",'" + date_string + "','"+ transactionID+"');", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("studentDashboard","login");
        }
       
        public ActionResult AddLessonForm(string course_id)
        {
            int id = Convert.ToInt32(course_id);
            ViewBag.course_id =id;
            return View();
        }

        public ActionResult AddLesson(string course_ID, string lesson_name, string lesson_desc, string lesson_link)
        {

            int id = Convert.ToInt32(course_ID);
            string name = lesson_name;
            string desc = lesson_desc;
            string link = lesson_link;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True"); //LAPTOP-AIC623KV
            SqlCommand sql;
            con.Open();

            sql = new SqlCommand("INSERT INTO lessons(course_ID, lesson_name, lesson_desc, lesson_link) Values(" + id + ",'" + name + "','" + desc + "','" + link +"');", con);
            sql.ExecuteNonQuery();
            con.Close();

            return View("AddLessonForm");
        }
        public ActionResult LessonList(string course_ID)
        {
            int id = Convert.ToInt32(course_ID);
            var lessons = db.lessons.Where(c => c.course_ID == id);
            return View(lessons.ToList());
        }
        public ActionResult EditLessonForm(string lesson_ID)
        {

            int id = Convert.ToInt32(lesson_ID);
            var lesson = db.lessons.Where(c => c.lesson_ID == id).FirstOrDefault();
           // ViewBag.course_ID = lesson.course_ID;
            ViewBag.lesson_name = lesson.lesson_name;
            ViewBag.lesson_desc = lesson.lesson_desc;
            ViewBag.lesson_link = lesson.lesson_link;
            return View();
        }

        public ActionResult EditLesson(string lesson_ID, string lesson_name, string lesson_desc, string lesson_link)
        {
            int id = Convert.ToInt32(lesson_ID);
            string name = lesson_name;
            string desc = lesson_desc;
            string link = lesson_link;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True");
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("UPDATE lessons SET lesson_name = '" + name + "' WHERE lesson_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            sql = new SqlCommand("UPDATE courses SET lesson_desc = '" + lesson_desc + "' WHERE lesson_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            sql = new SqlCommand("UPDATE courses SET course_image = '" + lesson_link + "' WHERE lesson_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminCourses");
        }

        public ActionResult DeleteLesson(string lesson_ID)
        {
            int id = Convert.ToInt32(lesson_ID);
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AIC623KV\SQLEXPRESS;Initial Catalog=elearning; Integrated Security=True"); //LAPTOP-AIC623KV
            SqlCommand sql;
            con.Open();
            sql = new SqlCommand("DELETE FROM lessons WHERE lesson_ID = " + id + ";", con);
            sql.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("AdminCourses");
        }
    }
}
