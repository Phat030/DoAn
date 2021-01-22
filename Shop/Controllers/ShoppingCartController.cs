using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        DatabaseOnlineShopContext _db = new DatabaseOnlineShopContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.Products.SingleOrDefault(s => s.IDProduct == id);
            if (pro!=null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro =int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart!=null)
            
                total_item = cart.Total_Quantity_in_Cart();
                ViewBag.QuantityCart = total_item;
                return PartialView("BagCart");
                      
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.OrderDate = DateTime.Now;
                _order.PhoneCus = int.Parse(form["PhoneCustomer"]);
                _order.AddressDelivery = form["Address_Delivery"];
                _db.Orders.Add(_order);
                foreach (var item in cart.Items)
                {
                    OrderDetail _order_Detail = new OrderDetail();
                    _order_Detail.IDOrder = _order.IDOrder;
                    _order_Detail.IDProduct = item._shopping_product.IDProduct;
                    _order_Detail.UnitPriceSale = item._shopping_product.UnitPrice;
                    _order_Detail.QuantitySale = item._shopping_quantity;
                    _db.OrderDetails.Add(_order_Detail);
                }
                _db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }
            catch 
            {
                return Content("Error Checkout. Please information of Customer...");                
            }
        }

        
    }
}