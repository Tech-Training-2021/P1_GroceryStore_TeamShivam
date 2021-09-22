using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entities
{
    public partial class CartDB : DbContext
    {
        public CartDB()
            : base("name=CartDB")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
