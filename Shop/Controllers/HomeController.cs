using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Net;
using System.Threading;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: Home        
        public ActionResult HomePage()
        {                     
            return View(_db.Products.ToList()); 
        }

        public ActionResult Category(string categories)
        {
            var products = _db.Products.Include(p => p.Category);
            if (!String.IsNullOrEmpty(categories))
            {
                int a = Convert.ToInt32(categories);
                products = products.Where(s => s.Category.IDCategory == a);
            }
            return View(products.ToList());
        }

        
        public ActionResult Search(string searchBy, string search)
        {
            if (searchBy == "NameProduct")
                return View(_db.Products.Where(s => s.NameProduct.StartsWith(search)).ToList());
            else if (searchBy == "Available")
                return View(_db.Products.Where(s => s.Available == search).ToList());

            return View(_db.Products.ToList());
        }

        
    }
}