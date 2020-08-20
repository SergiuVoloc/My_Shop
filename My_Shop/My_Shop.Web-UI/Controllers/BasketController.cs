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
        private readonly IOrderService orderService;

        public BasketController(IBasketService BasketService, IOrderService orderService)
        {
            this.basketService = BasketService;
            this.orderService = orderService;
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

        public ActionResult CheckOut()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CheckOut(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";

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