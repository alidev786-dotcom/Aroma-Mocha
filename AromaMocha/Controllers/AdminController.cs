using AromaMocha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AromaMocha.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult LoginAdmin(string email, string password)
        {
            List<Admin> admins = new List<Admin>() ;
            using(AromaMochaContext db = new AromaMochaContext())
            {
                admins = db.Admins.ToList();
            }
            foreach(var admin in admins)
            {
                if(admin.Email==email && admin.Password==password)
                {
                    Session["username"] = email;
                    Session["loggedInID"] = admin.ID;
                    Session["isAdmin"] = true;
                    ViewBag.success = "yes";
                    return Redirect("/Home/Index");
                }
            }
            ViewBag.invalidCredentials = true;
            return View("LoginPage");
        }

        public ActionResult ApproveTable(int tableID)
        {
            CafeTable table = new CafeTable();
            using(AromaMochaContext db = new AromaMochaContext())
            {
                List<CafeTable> tables = db.CafeTables.ToList();
                foreach(var t in tables)
                {
                    if(t.ID == tableID)
                    {
                        t.Status = "Approved";
                        t.isBooked = true;
                    }
                }
                db.SaveChanges();
            }
            return Redirect("/Reservation/Reservation");
        }
        public ActionResult LogoutAdmin()
        {
            Session.Remove("username");
            Session.Remove("loggedInID");
            Session.Remove("isAdmin");
            return View("LoginPage");
        }

        public ActionResult NewTable()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTable(CafeTable c)
        {
            using(AromaMochaContext db = new AromaMochaContext())
            {
                db.CafeTables.Add(c);
                db.SaveChanges();
            }
            return Redirect("/Reservation/Reservation");
        }

        public ActionResult DeleteTable(int? tableID)
        {
            using(AromaMochaContext db = new AromaMochaContext())
            {
                if(tableID != null)
                {
                    CafeTable toBeRemoved = db.CafeTables.FirstOrDefault(t => t.ID == tableID);
                    db.CafeTables.Remove(toBeRemoved);
                    db.SaveChanges();
                }
            }
            return Redirect("/Reservation/Reservation");
        }

        public ActionResult ShowFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();
            using (AromaMochaContext db = new AromaMochaContext())
            {
                feedbacks = db.Feedbacks.ToList();
            }
            return View(feedbacks);
        }
    }
}