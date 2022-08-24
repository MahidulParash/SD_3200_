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
        elearningEntities4 db = new elearningEntities4();
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

        
        [HttpGet]
        public ActionResult RegisterPage(int id=0)
        {
            student studentModel = new student();
            return View(studentModel);
        }

       [HttpPost]
        public ActionResult RegisterPage(student student)
        {
            using (elearningEntities4 db = new elearningEntities4())
            {
              
                if (db.students.Any(x => x.studentEmail==student.studentEmail))
                {
                    ViewBag.DuplicateMessage = "Username already exists";
                    return View("RegisterPage", student);
                }
                db.students.Add(student);
                db.SaveChanges();
                //return View();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("RegisterPage",new student());
        }
        [HttpGet]
        public ActionResult LoginPage()
        {
            student studentmodel = new student();
            return View(studentmodel);
        }
        [HttpPost]
        public ActionResult LoginPage(string loginEmail, string loginPassword)
        {
            using (elearningEntities4 db = new elearningEntities4())
            {
                var studentDetails = db.students.Where(x => x.studentEmail == loginEmail && x.studentPass == loginPassword).FirstOrDefault();
                var instructorDetails = db.instructors.Where(x => x.instructor_email == loginEmail && x.instructor_password == loginPassword).FirstOrDefault();
                if(instructorDetails!=null)
                {
                    Session["userEmail"] = instructorDetails.instructor_email;
                    Session["userName"] = instructorDetails.instructor_name;
                    Session["userID"] = instructorDetails.instructor_ID;
                    Session["userPassword"] = instructorDetails.instructor_password;

                    Session["userRole"] = "instuctor";
                    return RedirectToAction("instructorDashboard", "Admin");
                }
                else if (studentDetails != null)
                {
                    Session["userEmail"] = studentDetails.studentEmail;
                    Session["userName"] = studentDetails.studentName;
                    Session["userID"] = studentDetails.studentID;
                    Session["userRole"] = "student";
                    return RedirectToAction("studentDashboard", "login");
                }
                else
                {
                    ViewBag.loginError = "Login unsuccessful";
                }

            }
            return View();
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}