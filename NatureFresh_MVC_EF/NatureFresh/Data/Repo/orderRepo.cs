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
        public IEnumerable<Cart> GetCartItems(int UserId)
        
            {
            var items = (from item in db.Carts
                         where item.CustomerId == UserId
                         select item);
            return items.ToList();

        }


        public IEnumerable<InventoryItem> GetAllItems()
        {
            return db.InventoryItems.ToList();
        }


        //public IEnumerable<>

        [HttpPost]
        public void AddItemToCart(Cart cart)
        {
            db.Carts.Add(new Cart()
            {
                CustomerId = cart.CustomerId,
                ItemId = cart.ItemId,
                Weight = cart.Weight,
                Quantity = cart.Quantity
            });
            db.SaveChanges();
        }

        public void tmpCartItem(int id)
        {

        }
        public void UpdateCart(Cart cart)
        {
            Cart updatedCart  = (from item in db.Carts
                                where item.ItemId == cart.ItemId && item.CustomerId == cart.CustomerId
                                select item).FirstOrDefault();
            updatedCart.Quantity = cart.Quantity;
            updatedCart.Weight = cart.Weight;
            db.SaveChanges();
        }
        public void RemoveCartItem(int? UserId,int ItemId)
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
