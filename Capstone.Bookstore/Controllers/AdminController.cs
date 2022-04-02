using Newtonsoft.Json;
using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Model;
using Capstone.Bookstore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Bookstore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }

        public List<SelectListItem> GetAuthor()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Author>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.AuthorId.ToString(), Text = item.AuthorName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult Categories()
        {
            List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsActive == true).ToList();
            return View(allcategories);
        }

        public ActionResult UpdateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Category tbl)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(tbl);
            return RedirectToAction("Categories");
        }

        public ActionResult CategoryEdit(int categoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId));
        }

        [HttpPost]
        public ActionResult CategoryEdit(Tbl_Category tbl)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
            return RedirectToAction("Categories");
        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct());
        }

        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            ViewBag.AuthorList = GetAuthor();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Productimgs/"), pic);

                //file is uploaded
                file.SaveAs(path);
            }

            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            return RedirectToAction("Product");
        }

        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();

            ViewBag.AuthorList = GetAuthor();
            return View();
        }



        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string path = System.IO.Path.Combine(Server.MapPath("~/Productimg/"), pic);

                //file is uploaded
                file.SaveAs(path);
                tbl.ProductImage = string.Concat("/Productimg/", pic);
            }


            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            return RedirectToAction("Product");
        }
    }
}