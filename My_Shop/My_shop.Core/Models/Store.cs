using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Store
    {
        public string Id { get; set; } 
        public string Showroom { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }


        public Store()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
