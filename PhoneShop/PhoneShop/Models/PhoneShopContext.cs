using System;
using System.Data.Entity;

namespace PhoneShop.Models
{
    public class PhoneShopContext : DbContext, IDisposable
    {
        public PhoneShopContext() : base("PhoneShopContext") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}