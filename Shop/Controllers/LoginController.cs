using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Controllers
{
    public class LoginController : Controller
    {
        DatabaseOnlineShopContext db = new DatabaseOnlineShopContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //method login
        [HttpPost]
        public ActionResult Authen(User _user)
        {
            var check = db.Users.Where(s => s.Email.Equals(_user.Email) && s.Password.Equals(_user.Password)).FirstOrDefault();
            if (check == null)
            {
                _user.LoginErrorMessage = "Error Email or Password!!! Try again please!!!";
                return View("Index", _user);
            }
            else
            {
                var test = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (test.Email != "admin@gmail.com") //là khách hàng
                {
                    Session["IDUser"] = _user.IDUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("HomePage", "Home");
                }
                else //là admin
                {
                    return RedirectToAction("Index", "Product");
                }
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);
                if (check==null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists! Use another email please!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}