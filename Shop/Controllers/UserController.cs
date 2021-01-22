using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
namespace Shop.Controllers
{
    public class UserController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: User
        public ActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Users.Where(s => s.IDUser == id).FirstOrDefault());
        }

        

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.Users.Where(s => s.IDUser == id).FirstOrDefault());
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // TODO: Add update logic here
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // TODO: Add delete logic here
                user = _db.Users.Where(s => s.IDUser == id).FirstOrDefault();
                _db.Users.Remove(user);
                _db.SaveChanges();
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("IDUser is used for other table");
            }
        }
        
    }
}
