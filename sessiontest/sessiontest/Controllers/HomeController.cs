using sessiontest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sessiontest.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }


        public ActionResult About()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult Blog()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult BlogDetails()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        [Auth]
        public ActionResult Courses()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult Elements()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        [Auth]
        public ActionResult Instructor()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult Main()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }
        public ActionResult Contact()
        {
            if (Session["login"] != null)
            {
                ViewBag.Logined = true;
            }

            return View();
        }

        public ActionResult SignOut()
        {
            Session.Clear();

            ViewBag.Message = "Your contact page.";

            return RedirectToAction("SignIn","Auth");
        }
    }
}