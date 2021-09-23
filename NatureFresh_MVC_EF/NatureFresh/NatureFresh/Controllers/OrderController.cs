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
            Data.Entities.Cart cartobj = new Data.Entities.Cart();
            cartobj.CustomerId = 19;
            cartobj.ItemId = 2;
            cartobj.Weight = 250;
            cartobj.Quantity = 3;
            db.Carts.Add(cartobj);
            db.SaveChanges();
            //repo.AddItemToCart(Mapper.DbCartMapView(cart));
            //return View();
        }
        public void UpdateItemQnty(int qnty)
        {
            
        }



    }
}