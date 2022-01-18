using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using storeModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using storeModel.Models;
using storeModel.ViewModels;

namespace storeModel.Controllers
{
    public class HomeController : Controller
    {
        List<Laptop> laptops;
        List<Company> companies;

        public HomeController()
        {
            Company apple = new Company() { Country = "USA", Id = 1, Name = "Apple" };
            Company microsoft = new Company() { Country = "USA", Name = "Microsoft", Id = 2 };
            Company xiaomi = new Company() { Name = "Xiaomi", Id = 3, Country = "China" };
            companies = new List<Company> { apple, microsoft, xiaomi };

            laptops = new List<Laptop>()
            {
                new Laptop() {Id = 1, Name ="X1", Company = xiaomi, Price = 15000},
            new Laptop() { Id = 2, Name = "X2", Company = xiaomi, Price = 12000 },
            new Laptop() { Name = "Yoga", Id = 3, Company = microsoft, Price = 18100},
            new Laptop(){ Id = 4, Company = apple, Name = "MacBook", Price = 48000}

            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyModel> compModel = companies.Select(c=> new CompanyModel { Id = c.Id, Name = c.Name}).ToList();
            compModel.Insert(0, new CompanyModel { Id = 0, Name = "Все" });
            IndexViewModel ivm = new() { Companies = compModel, Laptops = laptops };

            if(companyId != null && companyId > 0)
            {
                ivm.Laptops = laptops.Where(p => p.Company.Id == companyId);
            }
            return View(ivm);
        }

        public IActionResult GetData(string[] items)
        {
            string result = "";
            foreach (string item in items)
                result += item + ";";
            return Content(result);
        }
    }
}
