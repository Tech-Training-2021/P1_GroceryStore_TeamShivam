using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}