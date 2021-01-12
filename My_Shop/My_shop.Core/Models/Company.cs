using My_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Core.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int IBAN { get; set; }

        public ICollection<Store> Store{ get; set; }
        public ICollection<Supplier> Supplier { get; set; }
        public ICollection<Courier> Courier { get; set; }

        //different approach
        //public List<Store> Store{ get; set; }

        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
