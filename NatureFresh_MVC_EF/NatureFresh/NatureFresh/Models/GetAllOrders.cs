using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class GetAllOrders
    {
        public int Id { get; set; }

        public int Users { get; set; }

        public int Outlets { get; set; }

        public int UsersAddress { get; set; }

        public DateTime Date { get; set; }

        public int TotalPrice { get; set; }
    }
}