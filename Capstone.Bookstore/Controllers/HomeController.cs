using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Model.Home;
using Capstone.Bookstore.Model.ViewModel;
using Capstone.Bookstore.Views.Home;

namespace Capstone.Bookstore.Controllers
{
    public class HomeController : Controller
    {
        dbBookStoreEntities ctx = new dbBookStoreEntities();
        public ActionResult Index(string search)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model.CreateModel(search));
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

        public RedirectToRouteResult AddToCart(int productId)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }


        public RedirectToRouteResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }

            }
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

    }
}