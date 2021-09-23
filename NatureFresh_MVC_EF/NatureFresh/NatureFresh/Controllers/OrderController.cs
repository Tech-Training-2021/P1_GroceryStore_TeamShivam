using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entities;
using Data.Repo;
using NatureFresh.Models;
using System.Web.Mvc;

namespace NatureFresh.Controllers
{
    public class OrderController : Controller

    {
        NatureFreshDB db = new NatureFreshDB();

        //Data.Repo.userRepo repo;
        orderRepo repo;

        public OrderController() // Mandatory Constructor, if not given the program will throw Exc 'repo is null'
        {
            repo = new orderRepo(new NatureFreshDB());
        }

        // GET: Order
        public ActionResult Index()
        {
            var items = repo.GetAllItems();
            return View("DispItems",items);
        }

        public void AddToCart(CartModel cart)
        {
            repo.AddItemToCart(Mapper.DbCartMapView(cart));
        }
        public void UpdateCart(CartModel cart)
        {
            repo.UpdateCart(Mapper.DbCartMapView(cart));
        }

        public void RemoveCartItem(Cart obj)
        {
            repo.RemoveCartItem(obj.CustomerId, obj.ItemId);
        }

        public ActionResult Cart()
        {
           var items = repo.GetCartItems((int)Session["UserId"]);
            return View(items);
        }
    }
}