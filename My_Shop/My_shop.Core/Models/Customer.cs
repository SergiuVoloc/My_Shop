using My_shop.Core.Models;


namespace My_Shop.Core.Models
{
    public class Customer : BaseEntity
    {
        public string UserId { get; set; }
        public string CustomerAddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public string BasketId { get; set; }
        public Basket Basket { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; } // remove Street + City + State + ZipCode for DB Normalisation
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


    }
}
