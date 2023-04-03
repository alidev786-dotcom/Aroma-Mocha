using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AromaMocha.Models;

namespace AromaMocha.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedback(string name, string email, string subject, string message)
        {
            using(AromaMochaContext db = new AromaMochaContext())
            {
                Feedback f = new Feedback() { Name = name, Email=email, Subject=subject, Message=message };
                db.Feedbacks.Add(f);
                db.SaveChanges();
            }
            return Redirect("/Home/Index");
        }
    }
}