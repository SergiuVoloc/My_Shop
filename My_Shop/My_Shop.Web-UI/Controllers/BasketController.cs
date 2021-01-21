using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Web_UI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IOrderService orderService;
        IRepository<Product> product;
        IRepository<Customer> customers;

        public BasketController(IBasketService BasketService, IOrderService orderService, IRepository<Customer> Customers, IRepository<Product> Product )
        {
            this.basketService = BasketService;
            this.orderService = orderService;
            this.customers = Customers;
            this.product = Product;
        }



        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }


        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
          
        }


        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }




        [Authorize]
        public ActionResult CheckOut()
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            Product testProduct = product.Find("5b5165dd-7b55-43db-b78f-3022bb60981c");
            Console.WriteLine("test");
            if (customer!=null)
            {
                Order order = new Order()
                {

                    UserId = customer.UserId,
                    FirstName = customer.FirstName,
                    SecondName = customer.SecondName,
                    City = customer.City,
                    State = customer.State,
                    Street = customer.Street,
                    ZipCode = customer.ZipCode,
                    Email = customer.Email,
             
                };

                OrderItem oItem = new OrderItem() {
                    OrderId = order.Id,
                    ProductId = testProduct.Id
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Error: ");
            }
            
        }



        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            // process payment

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }


        public ActionResult ThankYou(string OrderId )
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}