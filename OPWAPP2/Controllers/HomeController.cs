﻿using OPWAPP2.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OPWAPP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// <code></code>
        /// </summary>
        /// <returns></returns>
        public ActionResult FAQ()
        {
            ViewBag.Message = "FAQ page for users";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "OPWAPP contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Open OPWAPP Login page.";

            return View();
        }
        /*
         public ActionResult LoginErrorMessage()
        {
            ViewBag.Message = "Invalid Details";

            return View();
        }
        */
    }
}