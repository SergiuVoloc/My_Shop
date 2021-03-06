﻿using My_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Order : BaseEntity
    {

        public Order(){

            this.OrderItems = new List<OrderItem>();
        }

        public string UserId { get; set; }
        public string FirstName { get; set; } // remove FirstName + SecondName + Email for DB Normalisation
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OrderStatus { get; set; }
        public int ShippingCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }




    }
}
