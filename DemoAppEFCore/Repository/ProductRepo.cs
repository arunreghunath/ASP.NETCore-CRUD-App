using DemoAppEFCore.Data;
using DemoAppEFCore.Interfaces;
using DemoAppEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoAppEFCore.Repository
{
    public class ProductRepo : IProductRepo
    {
        private AppDbContext context;
        public ProductRepo(AppDbContext _context)
        {
            context = _context;
        }
        
        public Product GetProduct(long id)
        {
           
            return context.Products.Find(id);
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return context.Products;
        }
        public void CreateProduct(Product newProduct)
        {
            newProduct.Id = 0;
            context.Products.Add(newProduct);
            context.SaveChanges();
        }
        public void EditProduct(Product editProduct, Product OriginalProduct = null)
        {
            if (OriginalProduct == null)
            {
                OriginalProduct = context.Products.Find(editProduct.Id);
            }
            else
            {
                context.Products.Attach(OriginalProduct);
            }
            OriginalProduct.Name = editProduct.Name;
            OriginalProduct.Category = editProduct.Category;
            OriginalProduct.Price = editProduct.Price;
            context.SaveChanges();
        }
        public void DeleteProduct(long id)
        {
            context.Products.Remove(new Product { Id = id });
            context.SaveChanges();
        }
        public IEnumerable<Product> GetFilteredProducts(string category, decimal? price = null)
        {
            
            IQueryable<Product> data = context.Products;
            if (category != null)
            {

              data = data.Where(p => p.Category == category).Distinct();
            }
            if (price != null)
            {
                data = data.Where(p => p.Price >= price);
            }
            return data;
        }
        
      
    }
}
