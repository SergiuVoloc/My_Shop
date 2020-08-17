using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using My_Shop.Core.ViewModels;
using My_Shop.Services;
using My_Shop.Web_UI.Controllers;
using My_Shop.Web_UI.Tests.Mocks;

namespace My_Shop.Web_UI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTest
    {
        [TestMethod]
        public void CanAddBasketItem()
        {
            //setup
            IRepository<Basket> baskets = new Mocks.MockContext<Basket>();
            IRepository<Product> products = new Mocks.MockContext<Product>();

            var httpContext = new MockHttpContext();

            IBasketService basketService = new BasketService(products, baskets);

            //Act
            basketService.AddToBasket(httpContext, "1");

            Basket basket = baskets.Collection().FirstOrDefault();

            //Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);

        }


        [TestMethod]
        public void CanGetSummaryViewModel()
        {
            //setup
            IRepository<Basket> baskets = new Mocks.MockContext<Basket>();
            IRepository<Product> products = new Mocks.MockContext<Product>();

            products.Insert(new Product() { Id = "1", Price = 10});
            products.Insert(new Product() { Id = "2", Price = 5 });

            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem { ProductId = "1", Quantity = 2});
            basket.BasketItems.Add(new BasketItem { ProductId = "2", Quantity = 1 });
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);

            var controller = new BasketController(basketService);
            var httpContext = new MockHttpContext();

            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id }); //adding cookies to context

            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(25, basketSummary.BasketTotal);
        }
    }
}
