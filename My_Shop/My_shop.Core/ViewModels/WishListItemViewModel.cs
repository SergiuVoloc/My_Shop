﻿using My_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.ViewModels
{
    public class WishListItemViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
