using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entities
{
    public partial class NatureFreshDB : DbContext
    {
        public NatureFreshDB()
            : base("name=connectionSetting")
        {
        }

        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OutletAddress> OutletAddresses { get; set; }
        public virtual DbSet<Outlet> Outlets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryItem>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.InventoryItem)
                .HasForeignKey(e => e.InventoryItems);


            modelBuilder.Entity<OrderItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Orders);

            modelBuilder.Entity<OutletAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<OutletAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<OutletAddress>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<OutletAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<OutletAddress>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<OutletAddress>()
                .HasMany(e => e.Outlets)
                .WithOptional(e => e.OutletAddress1)
                .HasForeignKey(e => e.OutletAddress);

            modelBuilder.Entity<Outlet>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Outlet>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Outlet>()
                .Property(e => e.Fssai)
                .IsUnicode(false);

            modelBuilder.Entity<Outlet>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Outlet)
                .HasForeignKey(e => e.Outlets);

            modelBuilder.Entity<Outlet>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.Outlet)
                .HasForeignKey(e => e.Outlets);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.Roles);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.InventoryItems)
                .WithOptional(e => e.Unit)
                .HasForeignKey(e => e.Units);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.OrderItems)
                .WithOptional(e => e.Unit)
                .HasForeignKey(e => e.Units);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.UserAddress)
                .HasForeignKey(e => e.UsersAddress);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Aadhar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Users);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Outlets)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Users);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAddresses)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);
        }

        //public System.Data.Entity.DbSet<NatureFresh.Models.GetAllOrders> GetAllOrders { get; set; }
    }
}
