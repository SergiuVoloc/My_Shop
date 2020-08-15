﻿using My_Shop.Core.Models;
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
    }
}