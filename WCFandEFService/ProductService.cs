using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace WCFandEFService
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            ElectronicsStoreEntities context = new ElectronicsStoreEntities();
            var productEntity = (from p in context.ProductEntities
                                 where p.ProductID == id
                                 select p).FirstOrDefault();
            if (productEntity != null)
                return TranslateProductEntityToProduct(productEntity);
            else
                throw new Exception("Invalid product id");
        }

        private Product TranslateProductEntityToProduct(ProductEntity productEntity)
        {
            Product product = new Product();
            product.ProductID = productEntity.ProductID;
            product.Name = productEntity.Name;
            product.Description = productEntity.Description;
            product.Category = productEntity.Category;
            product.Price = (decimal)productEntity.Price;
            return product;
        }
    }
}