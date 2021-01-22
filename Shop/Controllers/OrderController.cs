using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: Order
        public ActionResult Index()
        {
            return View(_db.Orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Orders.Where(s => s.IDOrder == id).FirstOrDefault());
        }       

        
        public ActionResult Delete(int id)
        {
            return View(_db.Orders.Where(s => s.IDOrder == id).FirstOrDefault());
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                // TODO: Add delete logic here
                order = _db.Orders.Where(s => s.IDOrder == id).FirstOrDefault();
                _db.Orders.Remove(order);
                _db.SaveChanges();                
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("IDOrder is used for other table");
            }
        }
        
    }
}
