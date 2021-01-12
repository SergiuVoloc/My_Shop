using System;

namespace My_Shop.Core.Models
{
    public class CustomerAddress
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }




        public CustomerAddress()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}