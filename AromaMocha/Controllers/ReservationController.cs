using AromaMocha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AromaMocha.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Reservation()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            //getting logged in customer id
            int id = -1;
            if(Session["loggedInID"]!=null)
            {
                id = Convert.ToInt32(Session["loggedInID"]);
            }
            List<CafeTable> tables = new List<CafeTable>();
            using(AromaMochaContext db = new AromaMochaContext())
            {
                tables = db.CafeTables.ToList();
                //getting customer of this id
                Customer customer = db.Customers.ToList().Find(t => t.ID == id);
                ViewBag.Customer = customer;
            }
            return View(tables);
        }
        public ActionResult TableForm(int tableNumber, int tableID, int customerID, int tableCapacity)
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            int id = Convert.ToInt32(TempData["loggedInID"]);
            List<Customer> customers = (new AromaMochaContext()).Customers.ToList();
            for(int i=0; i<customers.Count; i++)
            {
                if(customers[i].ID == id)
                {
                    ViewBag.name = customers[i].Name;
                }
            }
            ViewBag.tableNumber = tableNumber;
            ViewBag.customerID = customerID;
            ViewBag.tableID = tableID;
            ViewBag.tableCapacity = tableCapacity;
            return View();
        }

        [HttpPost]
        public ActionResult BookTable(int? tableID, int? customerID, DateTime? bookingDate)
        {
            using(AromaMochaContext db = new AromaMochaContext())
            {
                CafeTable table = db.CafeTables.Find(tableID);
                table.CustomerID = customerID;
                table.BookingDate = bookingDate;
                table.Status = "Pending";
                table.isBooked = false;
                db.SaveChanges();
            }
            return Redirect("/Reservation/Reservation");
        }
    }
}