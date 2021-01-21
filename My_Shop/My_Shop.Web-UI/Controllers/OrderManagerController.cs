using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService orderService;
        IRepository<Product> product;

        public OrderManagerController(IOrderService OrderService, IRepository<Product> Product)
        {
            orderService = OrderService;
            product = Product;
        }

        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetListOfOrders();
            return View(orders);
        }

        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>(){
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Completed"
            };

            Order order = orderService.GetOrder(Id);
            foreach (var item in order.OrderItems) {
                item.Product = product.Find(item.ProductId);
            }
            // foreach order.OrderItems
            //SelectList iau oate produsele din lista
            

            //de trimis orderItems dar cu produse impreuna 
            return View(order);
        }


        [HttpPost]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}