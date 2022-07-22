using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSE3200.Models
{
    public class Student
    {
        public int studentID { get; set; }
        public string studentEmail { get; set; }
        public string studentName { get; set; }
        public string password { get; set; }
    }
}