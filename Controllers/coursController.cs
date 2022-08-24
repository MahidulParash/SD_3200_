using System;
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
        private elearningEntities4 db = new elearningEntities4();

        // GET: cours
        public ActionResult Index()
        {
            var courses = db.courses.Include(c => c.instructor);
            return View(courses.ToList());
        }

        public ActionResult AdminCourses()
        {
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
                return RedirectToAction("/Admin/instructorDashboard");
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

        //// POST: cours/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        ////public ActionResult DeleteConfirmed(int id)
        ////{
        ////    cours cours = db.courses.Find(id);
        ////    db.courses.Remove(cours);
        ////    db.SaveChanges();
        ////    return RedirectToAction("Index");
        ////}

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
    }
}
