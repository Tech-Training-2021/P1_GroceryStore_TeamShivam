using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data.Repo
{
    public class orderRepo
    {
        private NatureFreshDB db;

        public orderRepo(NatureFreshDB db)
        {
            this.db = db;
        }
        public IEnumerable<Cart> GetCartItems()
        {
            return db.Carts.ToList();
        }


        public IEnumerable<InventoryItem> GetAllItems()
        {
            return db.InventoryItems.ToList();
        }

        [HttpPost]
        public void AddItemToCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public void UpdateCartQuantity(int UserId,int ItmId, int qty,int wt)
        {
            Cart updatedCart  = (from item in db.Carts
                                where item.ItemId == ItmId && item.CustomerId == UserId
                                select item).FirstOrDefault();
            updatedCart.Quantity = qty;
            updatedCart.Weight = wt;
            db.SaveChanges();
        }
        public void RemoveCartItem(int UserId,int ItemId)
        {
            var CartItem = (from item in db.Carts
                        where item.ItemId == ItemId && item.CustomerId == UserId
                        select item).FirstOrDefault();
            if (CartItem != null)
            {
                db.Carts.Remove(CartItem);
                db.SaveChanges();
            }
            else
                throw new ArgumentException("Item is not found");
        }
    }
}
