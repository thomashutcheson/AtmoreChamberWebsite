﻿using AtmoreChamber.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AtmoreChamberPinnacle.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = db.Products.FirstOrDefault(p => p.ProductID == id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = db.Products.FirstOrDefault(p => p.ProductID == id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            if (cart[index].Quantity > 0)
            {
                cart[index].Quantity--;
            }
            Session["cart"] = cart;
            return RedirectToAction("Index", "Products");
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductID.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult CartBuy(int id)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = db.Products.FirstOrDefault(p => p.ProductID == id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = db.Products.FirstOrDefault(p => p.ProductID == id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult CartRemove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            Session["cart"] = cart;
            return RedirectToAction("Index", "Cart");
        }





    }
}