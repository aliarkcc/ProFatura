using Microsoft.AspNetCore.Mvc;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Controllers
{
    public class SuppliersController : Controller
    {
        ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result= _supplierService.GetAll().ToList();
            return View(result);
        }
    }
}
