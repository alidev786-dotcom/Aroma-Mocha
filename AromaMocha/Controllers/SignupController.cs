using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AromaMocha.Models;

namespace AromaMocha.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Signup()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            return View();
        }

        [HttpPost]
        public ActionResult registerCustomer(Customer c)
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            AromaMochaContext db = new AromaMochaContext();
            db.Customers.Add(c);
            db.SaveChanges();
            Session["username"] = c.Email;
            Session["loggedInID"] = c.ID;
            Session["isAdmin"] = false;
            return Redirect("/Home/Index");
        }

    }
}