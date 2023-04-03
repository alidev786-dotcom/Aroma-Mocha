using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AromaMocha.Models;

namespace AromaMocha.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            return View();
        }


        public string test()
        {
            return "success";
        }

        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            //TempData.Keep("username");
            //getting list of all customers
            List<Customer> customers = new AromaMochaContext().Customers.ToList();
            for(int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Email == email && customers[i].Password == password)
                {
                    Session["username"] = email;
                    Session["loggedInID"] = customers[i].ID;
                    Session["isAdmin"] = false;
                    ViewBag.success = "yes";
                    return Redirect("/Home/Index");
                }
            }
            ViewBag.invalidCredentials = true;
            return View("Register");
        }

        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("loggedInID");
            Session.Remove("isAdmin");
            return View("Register");
        }
    }
}