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
        IRepository<Customer> customers;

        public BasketController(IBasketService BasketService, IOrderService orderService, IRepository<Customer> Customers)
        {
            this.basketService = BasketService;
            this.orderService = orderService;
            this.customers = Customers;
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

            if (customer!=null)
            {
                Order order = new Order()
                {
                    FirstName = customer.FirstName,
                    SecondName = customer.SecondName,
                    City = customer.City,
                    State = customer.State,
                    Street = customer.Street,
                    ZipCode = customer.ZipCode,
                    Email = customer.Email
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