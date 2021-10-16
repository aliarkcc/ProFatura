using Microsoft.AspNetCore.Mvc;
using ProFatura.Entity.Concrete;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _productService.GetAll().ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        { 
            product.UnitPrice = 4.20;
            _productService.Add(product);
            return RedirectToAction("Index");
        }
    }
}
