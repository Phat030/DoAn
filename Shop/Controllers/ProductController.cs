using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: Product
        
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "NameProduct")
                return View(_db.Products.Where(s => s.NameProduct.StartsWith(search)).ToList());
            else if (searchBy == "Available")
                return View(_db.Products.Where(s => s.Available == search).ToList());
            else
                return View(_db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Products.Where(s=>s.IDProduct==id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                // TODO: Add insert logic here
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.Image = "~/Content/Image/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), fileName));
                }
                _db.Products.Add(pro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.Products.Where(s=>s.IDProduct==id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                // TODO: Add update logic here
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.Image = "~/Content/Image/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), fileName));
                }
                _db.Entry(pro).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Products.Where(s=>s.IDProduct==id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                // TODO: Add delete logic here
                pro = _db.Products.Where(s => s.IDProduct == id).FirstOrDefault();
                _db.Products.Remove(pro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ChooseCategory()
        {
            Category cate = new Category();
            cate.CateCollection = _db.Categories.ToList<Category>();
            return PartialView(cate);
        }

        
    }
}
