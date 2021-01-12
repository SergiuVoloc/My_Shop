using System.Collections.Generic;
using System.Web;
using My_Shop.Core.ViewModels;

namespace My_Shop.Core.Contracts
{
    public interface IWishListService
    {
        void AddToWishList(HttpContextBase httpContext, string productId);
        void RemoveFromWishList(HttpContextBase httpContext, string itemId);
        List<WishListItemViewModel> GetWishListItems(HttpContextBase httpContext);
        void ClearWishList(HttpContextBase httpContext);
    }
}