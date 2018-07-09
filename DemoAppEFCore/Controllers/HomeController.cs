using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppEFCore.Data;
using DemoAppEFCore.Interfaces;
using DemoAppEFCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace DemoAppEFCore.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo repo;
        public HomeController(IProductRepo _repo)
        {
           repo = _repo;
        }
        [HttpGet]
        public IActionResult Index(string category = null, decimal? price = null)
        {
            var products = repo.GetFilteredProducts(category, price);
            ViewBag.category = category;
            ViewBag.price = price;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Product product)
        {
            repo.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", repo.GetProduct(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Product product, Product original)
        {
            repo.EditProduct(product, original);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(long id)
        {
            repo.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
