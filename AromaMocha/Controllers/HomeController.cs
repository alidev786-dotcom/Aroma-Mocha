using AromaMocha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AromaMocha.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            AromaMochaContext db = new AromaMochaContext();
            //db.Admins.Add(new Admin()
            //{
            //    ID = 1,
            //    Email = "admin@gmail.com",
            //    Password = "admin"
            //});
            //db.CafeTables.Add(new CafeTable()
            //{
            //    TableNumber = 4,
            //    TableCapacity = 2,    
            //    isBooked = false,
            //    Status = "available"
            //});
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            return View();
        }
    }
}