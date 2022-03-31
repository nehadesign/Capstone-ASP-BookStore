using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Model.Home;
using Capstone.Bookstore.Model.ViewModel;

namespace Capstone.Bookstore.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}