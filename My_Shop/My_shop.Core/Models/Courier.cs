using My_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Courier 
    {
        public string Id { get; set; }

        public Courier()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
