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
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "User", new { area = "" });
            var items = repo.GetAllItems();
            return View("DispItems",items);
        }

        public void AddToCart(Models.CartModel cart)
        {
            repo.AddItemToCart(Mapper.DbCartMapView(cart));
        }
        public void UpdateCart(Models.CartModel cart)
        {
            repo.UpdateCart(Mapper.DbCartMapView(cart));
        }

        public void RemoveCartItem(Cart obj)
        {
            repo.RemoveCartItem((int?)obj.CustomerId, obj.ItemId);
        }

        public ActionResult Cart()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "User", new { area = "" });
            var items = repo.GetCartItems((int)Session["UserId"]);
            return View(items);
        }

        public ActionResult Checkout(int? OutletId)
        {
            int sessionId = Convert.ToInt32(Session["UserId"]);
            OutletId = 13;
            if(Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }
            var res = (from u in db.Carts where u.CustomerId ==sessionId select u);

            Order OrderObj = new Order();

            OrderItem OrderItem = new OrderItem();

            Data.Entities.Cart temp = new Data.Entities.Cart();
            decimal totalPrice = 0;

            foreach(var item in res)
            {
                temp = item;
                totalPrice += getPrice((int)item.Quantity, (int)item.Weight, (int)item.Item.Price, item.Item.Unit.Name);

            }
            var userAddress = temp.User.UserAddresses.FirstOrDefault().Id;


            OrderObj.Users = (int)Session["UserId"];
            OrderObj.Outlets = OutletId;
            OrderObj.UsersAddress = userAddress;
            OrderObj.Date = DateTime.Now;
            OrderObj.TotalPrice = (int)totalPrice;

            int orderID = repo.AddOrder(OrderObj);

            foreach (var item in res)
            {
                OrderItem OrderItemObj = new OrderItem();
                OrderItemObj.Orders = orderID;
                OrderItemObj.Name = item.Item.Name;
                OrderItemObj.Quantity = item.Quantity;
                OrderItemObj.Weight = item.Weight;
                OrderItemObj.Price = item.Item.Price;
                OrderItemObj.Units = item.Item.Unit.Id;
                repo.AddOrderItem(OrderItemObj);
                repo.RemoveCartItem2(sessionId, item.Item.ID);
            }
            repo.Save();

            return View();
        }

         decimal getPrice(int qty, int wt, int rate, string unit)
         {
             int totQnty = qty * wt;
             decimal price;
             if (unit == "gram")
             {
                 price = ((decimal)totQnty / 1000) * rate;
             }
             else
             {
                 price = qty * rate;
             }
             return Math.Ceiling(price);
         }
    }
}