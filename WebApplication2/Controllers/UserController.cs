using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (user.isValid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Incorrect Login");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
           FormsAuthentication.SignOut();
           return  RedirectToAction("Index", "home");
        }
    }
}