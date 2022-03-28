using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Bookstore.Model.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbBookStoreEntities context = new dbBookStoreEntities();
        public IQueryable<Tbl_Product> ListOfProducts { get; set; }
        public HomeViewModel CreateModel(string search, int pageSize, int? page)
        {
            //Pagination

            var bookData = context.Tbl_Product
                 .Where(p => p.IsActive == true)
                 .Where(p => p.IsDelete == false)
                 .Skip((int)(page - 1) * pageSize).Take(pageSize);

            return new HomeViewModel
            {
                ListOfProducts = bookData

            };
        }
    }
}