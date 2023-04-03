using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AromaMocha.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Menu()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            return View();
        }
    }
}