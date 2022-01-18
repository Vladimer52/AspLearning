using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace models.Controllers
{
    public class HomeController : Controller
    {
        List<Phone> phones;
        List<Company> companies;

        public HomeController()
        {
            Company apple = new Company { Name = "Apple", Id = 1, Country = "USA" };
            Company microsoft = new Company { Name = "Mictosoft", Id = 2, Country = "German" };
            Company xiaomi = new Company { Name = "Xiaomi", Id = 3, Country = "China" };
            companies = new List<Company> { apple, microsoft, xiaomi };

            phones = new List<Phone>
            {
                new Phone { Id=1, Company= apple, Name="iPhone X", Price=56000 },
                new Phone { Id=2, Company= apple, Name="iPhone XZ", Price=41000 },
                new Phone { Id=3, Company= microsoft, Name="Galaxy 9", Price=9000 },
                new Phone { Id=4, Company= microsoft, Name="Galaxy 10", Price=40000 },
                new Phone { Id=5, Company= xiaomi, Name="Pixel 2", Price=30000 },
                new Phone { Id=6, Company= xiaomi, Name="Pixel XL", Price=50000 }
            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyViewModel> compModels = companies
                .Select(company => new CompanyViewModel { Id = company.Id, Name = company.Name })
                .ToList();
            //добавляем на первое место "все"
            compModels.Insert(0, new CompanyViewModel { Name = "Все", Id = 0 });
            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };

            if(companyId != null && companyId > 0)
            {
                ivm.Phones = phones.Where(p => p.Company.Id == companyId);

            }
            return View(ivm);
        }

        public IActionResult AddPhone([Bind("Name", "Price", "HasRight")]Phone phone)
        {
            if (ModelState.IsValid)
            {
                string PhoneInfo = $"Id = {phone.Id}, Name = {phone.Name}, Price = {phone.Price}, HasRight = {phone.HasRight}";
                return Content(PhoneInfo);
            }
            return Content($"Количество ошибок: {ModelState.ErrorCount}");
        }
    }
}
