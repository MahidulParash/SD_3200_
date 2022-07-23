
using SD_3200_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSE3200.Controllers
{
    public class StudentController : Controller
    {
        elearningEntities1 db = new elearningEntities1();
        //adds a new user to the database
        //validation Handling
        public ActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateUser([Bind(Include = "studentName, studentEmail, studentPass")] student student)
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