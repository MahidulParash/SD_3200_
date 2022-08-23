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


        // GET: cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cours cours = db.courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

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

        public ActionResult EditCourses(string coursedit)
        {
            var id = Convert.ToInt32(coursedit);
            var courses = db.courses.Where(c => c.course_ID == id);
            return View(courses.ToList());
        }
    }
}
