using Capstone.Bookstore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Bookstore.Model.ViewModel
{
    public class BaseViewModel
    {
        public List<Tbl_Category> Categories => DBEntity.Tbl_Category.Where(cat => cat.IsActive == true).ToList();
        private dbBookStoreEntities DBEntity = new dbBookStoreEntities();
       
    }
}