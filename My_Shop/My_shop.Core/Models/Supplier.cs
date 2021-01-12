using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Supplier
    {
        public string Id { get; set; }
        public string Status { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }


        public Supplier()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
