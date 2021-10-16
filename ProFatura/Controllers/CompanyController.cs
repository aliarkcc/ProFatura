using Microsoft.AspNetCore.Mvc;
using ProFatura.Entity.Concrete;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result= _companyService.GetAll().ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _companyService.Add(company);
            return RedirectToAction("Index");
        }
    }
}
