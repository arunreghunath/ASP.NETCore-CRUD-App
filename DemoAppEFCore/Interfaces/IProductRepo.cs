using DemoAppEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppEFCore.Interfaces
{
    public interface IProductRepo 
    {
        Product GetProduct(long id);
        IEnumerable<Product> GetAllProduct();
        void CreateProduct(Product newProduct);
        void EditProduct(Product editProduct, Product OriginalProduct = null);
        void DeleteProduct (long id);
        IEnumerable<Product> GetFilteredProducts(string category, decimal? price = null);
      
        
    }
}
