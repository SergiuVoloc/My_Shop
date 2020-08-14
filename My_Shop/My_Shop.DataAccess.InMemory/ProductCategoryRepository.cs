using My_Shop.Core.Models;
using My_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["products"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["products"] = productCategories;
        }


        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory product)
        {
            ProductCategory productToUpdate = productCategories.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product Category not found!");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCategories.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Category not found!");
            }
        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }


        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }
    }
}
