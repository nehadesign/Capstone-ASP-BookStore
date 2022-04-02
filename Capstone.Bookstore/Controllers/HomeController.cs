using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Model.Home;
using Capstone.Bookstore.Model.ViewModel;
using Capstone.Bookstore.Model;
using Capstone.Bookstore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public ActionResult Checkout()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CheckoutDetails()
        {
            //ViewBag.Message = "Your contact page.";

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
                var result = cart.Where(x => x.Product.ProductId == productId).FirstOrDefault();
                if (result != null)
                {
                    cart.Where(x => x.Product.ProductId == productId).FirstOrDefault().Quantity += 1;
                }
                else
                {
                    var product = ctx.Tbl_Product.Find(productId);
                    cart.Add(new Item()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult AddCountToCart(int productId)
        {

            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var result = cart.Where(x => x.Product.ProductId == productId).FirstOrDefault();
                if (result != null)
                {
                    cart.Where(x => x.Product.ProductId == productId).FirstOrDefault().Quantity += 1;
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Checkout");
        }

        public RedirectToRouteResult RemoveCountFromCart(int productId)
        {

            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var result = cart.Where(x => x.Product.ProductId == productId && x.Quantity > 0).FirstOrDefault();
                if (result != null)
                {
                    cart.Where(x => x.Product.ProductId == productId).FirstOrDefault().Quantity -= 1;
                }

                Session["cart"] = cart;
            }
            return RedirectToAction("Checkout");
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

        public PartialViewResult Categories()
        {

            var model = ctx.Tbl_Category.Where(cat => cat.IsActive == true).ToList();
            return PartialView("~/Views/Shared/_Categories.cshtml", model);
        }

        public ActionResult Category(int id = 1)
        {
            var model = ctx.Tbl_Product.Include("Tbl_Category").Where(x => x.CategoryId == id);

            return View(model);
        }


    }
}