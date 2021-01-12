using My_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class WishList :BaseEntity
    {
        public string WishListId { get; set; }
        public int Quantity { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }


        public  ICollection<WishList> WishListItems { get; set; }

        public WishList()
        {
            this.WishListItems = new List<WishList>();
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
