using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shop.Models
{
    public class DatabaseOnlineShopContext:DbContext
    {
        public DatabaseOnlineShopContext() : base("DatabaseOnlineShopContext") {
            this.Database.Connection.ConnectionString= "workstation id=pbstore.mssql.somee.com;packet size=4096;user id=Vy7030_SQLLogin_1;pwd=4nhzbrjul9;data source=pbstore.mssql.somee.com;persist security info=False;initial catalog=pbstore";
        }
        public DatabaseOnlineShopContext(string connectionString) : base(connectionString) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }        
    }
}