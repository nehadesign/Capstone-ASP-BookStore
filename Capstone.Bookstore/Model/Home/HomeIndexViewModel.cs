using Capstone.Bookstore.DAL;
using Capstone.Bookstore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Bookstore.Model.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel()
        {

            return new HomeIndexViewModel()
            {
                ListOfProducts = _unitOfWork.GetRepositoryInstance<Tbl_Product>().GetAllRecords()
        };
        }
    }
}