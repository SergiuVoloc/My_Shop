using My_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class OrderItem: BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; } 
        public Product Product { get; set; }
        public string ProductName { get; set; } // remove ProductName + Price + Image for DB Normalisation
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
