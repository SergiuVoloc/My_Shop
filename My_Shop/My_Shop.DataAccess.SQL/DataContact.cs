using My_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.DataAccess.SQL
{
    public class DataContact : DbContext
    {
        public DataContact() 
            :base("DefaultConnection"){
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Store> Stores { get; set; }

        public System.Data.Entity.DbSet<My_Shop.Core.ViewModels.WishListItemViewModel> WishListItemViewModels { get; set; }
    }
} 
