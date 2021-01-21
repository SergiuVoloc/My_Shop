using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using My_Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
        orderContext = OrderContext;

        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    //Image = item.Image,
                    //Price = item.Price,
                    //ProductName = item.ProductName,
                    //Quantity = item.Quantity

                });

            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        public List<Order> GetListOfOrders()
        {
            return orderContext.Collection().ToList();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updateOrder)
        {
            orderContext.Update(updateOrder);
            orderContext.Commit();
        }
    }
}

