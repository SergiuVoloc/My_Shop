using My_Shop.Core.Contracts;
using My_Shop.Core.Models;
using My_Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace My_Shop.Services
{
    public class WishListService :IWishListService
    {
        IRepository<Product> productContext;
        IRepository<WishList> wishListContext;

        public const string WishListSectionName = "eCommerceWishList";

        public WishListService(IRepository<Product> ProductContext, IRepository<WishList> WishListContext)
        {
            this.wishListContext = WishListContext;
            this.productContext = ProductContext;
        }

        private WishList GetWishList(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(WishListSectionName);

            WishList wishList = new WishList();

            if (cookie!=null)
            {
                string wishListId = cookie.Value;
                if (!string.IsNullOrEmpty(wishListId))
                {
                    wishList = wishListContext.Find(wishListId);
                }
                else
                {
                    if (createIfNull) 
                    {
                        wishList = CreateNewWishList(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    wishList = CreateNewWishList(httpContext);
                }
            }
            return wishList;
        }



        private WishList CreateNewWishList(HttpContextBase httpContext)
        {
            WishList wishList = new WishList();
            wishListContext.Insert(wishList);
            wishListContext.Commit();

            HttpCookie cookie = new HttpCookie(WishListSectionName);
            cookie.Value = wishList.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return wishList;
        }




        public void AddToWishList(HttpContextBase httpContext, string productId)
        {
            WishList wishList = GetWishList(httpContext, true);
            WishList item = wishList.WishListItems.FirstOrDefault(i => i.ProductId == productId);

            //if item doesn't the  exist in the WishList
            if (item == null)
            {
                item = new WishList()
                {
                    WishListId = wishList.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                wishList.WishListItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }
            wishListContext.Commit();
        }




        public void RemoveFromWishList(HttpContextBase httpContext, string itemId)      // CONTINUE FROM HERE
        {
            WishList WishList = GetWishList(httpContext, true);
            WishListItem item = WishList.WishListItems.FirstOrDefault(i=>i.Id==itemId);

            if (item != null)
            {
                WishList.WishListItems.Remove(item);
                WishListContext.Commit();
            }
        }




        public List<WishListItemViewModel> GetWishListItems(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);

            if (WishList != null)
            {
                //if we retrieved the WishList, we query the product table and WishList items to get info
                var results = (from b in WishList.WishListItems
                              join p in productContext.Collection()
                              on b.ProductId equals p.Id
                              select new WishListItemViewModel()
                              {
                                  Id = b.Id,
                                  Quantity = b.Quantity,
                                  ProductName = p.Name,
                                  Image = p.Image,
                                  Price = p.Price
                              }
                              ).ToList();
                return results;
            }
            else
            {
                return new List<WishListItemViewModel>();
            }
        }
        //return a total no of items of the items and total quantity in the WishList
        public WishListSummaryViewModel GetWishListSummary(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);
            WishListSummaryViewModel model = new WishListSummaryViewModel(0,0);

            if (WishList != null)
            {
                // if we have items in the WishList, we need to calculate how many items are in the WishList
                // int? -> means we can store a non value
                int? WishListCount = (from item in WishList.WishListItems
                                    select item.Quantity).Sum();

                decimal? WishListTotal = (from item in WishList.WishListItems
                                        join p in productContext.Collection()
                                        on item.ProductId equals p.Id
                                        select item.Quantity * p.Price).Sum();

                //assigning values to the model
                model.WishListCount = WishListCount ?? 0; // ?? -> if `WishListcount` is null then return 0
                model.WishListTotal = WishListTotal ?? decimal.Zero;

                return model;
            }
            else
            {
                return model; // if the WishList is empty, return default constructor with 0 elemets
            }
        }

        public void ClearWishList(HttpContextBase httpContext)
        {
            WishList WishList = GetWishList(httpContext, false);
            WishList.WishListItems.Clear();
            WishListContext.Commit();
        }

    }
}
