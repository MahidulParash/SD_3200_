using CSE3200.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSE3200.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student{studentID=11,studentEmail="tasnia@gmail.com",studentName="Tasnia",password="1234"},
            new Student{studentID=12,studentEmail="nabila@gmail.com",studentName="Tasnia",password="1234"},
            new Student{studentID=13,studentEmail="tabila@gmail.com",studentName="Tasnia",password="1234"}

        };
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.num = 1;
            ViewBag.students = students;
            return View();
        }
        public ActionResult showStudents()
        {
            
            return View(students);
        }
    }
}