using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using My_Shop.DataAccess.SQL;

namespace My_Shop.Web_UI.Controllers
{
    public class WishListController : Controller
    {
        IWishListService wishListService;
        IRepository<Customer> customers;

        public WishListController(IWishListService WishListService, IRepository<Customer> Customers)
        {
            this.wishListService = WishListService;
            this.customers = Customers;
        }

        // GET: WishLists
        public ActionResult Index()
        {
            var model = wishListService.GetWishListItems(this.HttpContext);
            return View(model);
        }


        public ActionResult AddToWishList(string Id)
        {
            wishListService.AddToWishList(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromWishList(string Id)
        {
            wishListService.RemoveFromWishList(this.HttpContext, Id);

            return RedirectToAction("Index");

        }





      
    }
}