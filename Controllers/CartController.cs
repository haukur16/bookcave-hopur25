using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookCave.Helpers;
using BookCave.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using BookCave.Models;
using BookCave.Data.EntityModels;

namespace BookCave.Controllers
{
    [Route("cart")]
  public class CartController : Controller
    {
        private DataContext db = new DataContext();

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session,"cart");
            ViewBag.cart = cart;
            //ViewBag.total = cart.Sum(i => i.Book.Price * i.Quantity);
            return View();
            
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Cart>();
                cart.Add(new Cart() {Book = db.Books.Find(id), Quantity = 1});
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                var index = Exists(cart, id);
                if(index == -1)
                {
                    cart.Add(new Cart(){ Book = db.Books.Find(id), Quantity = 1});
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        [Route("increase/{id}")]
        public IActionResult Increase(int id)
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart[index].Quantity++;
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

                [Route("decrease/{id}")]
        public IActionResult Decrease(int id)
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart[index].Quantity--;
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int Exists (List<Cart> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Book.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}