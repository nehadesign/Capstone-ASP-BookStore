using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Bookstore.Controllers
{
    public class AuthenticationController : Controller
    {
        
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }
    }
}