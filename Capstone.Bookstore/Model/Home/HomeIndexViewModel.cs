using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Model.ViewModel;
using Capstone.Bookstore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Capstone.Bookstore.Model.Home
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
       // public int PageSize => 4;
       
        dbBookStoreEntities context = new dbBookStoreEntities();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search = null, int? page = null)
        {
            dbBookStoreEntities dbBookStoreEntities = new dbBookStoreEntities();
            var results = context.Tbl_Product.Include("Tbl_Author").Where(x => x.ProductName.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 4);
            
            return new HomeIndexViewModel()
            {
                ListOfProducts = results
            };
        }
    }
}