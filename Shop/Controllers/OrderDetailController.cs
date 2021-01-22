using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderDetailController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View(_db.OrderDetails.ToList());
        }

        // GET: OrderDetail/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.OrderDetails.Where(s => s.IDOrderDetail == id).FirstOrDefault());
        }          

    }
}
