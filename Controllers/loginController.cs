﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SD_3200_.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult studentDashboard()
        {
            return View();
        }
        public ActionResult adminDashboard()
        {
            return View();
        }
    }
}