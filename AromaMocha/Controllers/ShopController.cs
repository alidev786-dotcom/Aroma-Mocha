using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AromaMocha.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Shop()
        {
            //TempData.Keep("username");
            //TempData.Keep("loggedInID");
            return View();
        }
    }
}