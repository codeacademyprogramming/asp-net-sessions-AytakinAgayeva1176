using sessiontest.Context;
using sessiontest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace sessiontest.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        EduContext db = new EduContext();


        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var isPasswordMatch = Crypto.VerifyHashedPassword(user.Password, password);

                if (isPasswordMatch)
                {
                    Session["login"] = true;
                    Session["userid"] = user.id;

                    //var str = user.Username;
                    
                    //if (str.Length == 1)
                    //{
                    //    str = str.ToUpper();
                    //}
                      
                    //else
                    //  str=  char.ToUpper(str[0]) + str.Substring(1);

                    Session["username"] = user.Username;


                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("Password", "Password is not correct ");
                }
            }

            else
            {
                ModelState.AddModelError("Username", "Username or Password is not correct");
            }

            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (db.Users.FirstOrDefault(x => x.Username == user.Username) != null)
            {
                ModelState.AddModelError("Username", "Username already exists");
            }

            if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                ModelState.AddModelError("Emal", "Email already exists");
            }

            if (ModelState.IsValid)
            {
                var hashpassword = Crypto.HashPassword(user.Password);
                user.Password = hashpassword;
                user.ConfirmPassword = hashpassword;
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("SignIn");
            }

            return View(user);
        }
    }
}