using My_shop.Core.Models;
using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Product : BaseEntity
    {
   
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Category { get; set; } // remove Category for DB Normalisation
        public string Stock { get; set; }
        public string Image { get; set; }

        public string CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public string StoreId { get; set; }
        public Store Store { get; set; }


    }
}
