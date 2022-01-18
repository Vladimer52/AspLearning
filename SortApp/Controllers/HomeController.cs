using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SortApp.Models;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models;

namespace SortApp.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            this.db = context;
            if(db.Companies.Count() == 0)
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
                User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
                User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
                User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
                User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

                db.Companies.AddRange(oracle, microsoft, apple, google);
                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                db.SaveChanges();
            }
        }

        public IActionResult Index(int? company, string name)
        {
            IQueryable<User> users = db.Users.Include(x => x.Company);
            //сортировка
            /* ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
             ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
             ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
             users = sortOrder switch
  {
      SortState.NameDesc => users.OrderByDescending(s => s.Name),
      SortState.AgeAsc => users.OrderBy(s => s.Name),
      SortState.AgeDesc => users.OrderByDescending(s => s.Name),
      SortState.CompanyAsc => users.OrderBy(s => s.Name),
      SortState.CompanyDesc => users.OrderByDescending(s => s.Name),
      _ => users.OrderBy(s => s.Name),
  };*/

            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }
            List<Company> companies = db.Companies.ToList();
            //устанавливаем первый элемент, который позволит выбрать всех
            companies.Insert(0, new Company { Id = 0, Name = "Все" });
            UserListViewModel viewModel = new UserListViewModel
            {
                Users = users.ToList(),
                Companies = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(companies, "Id", "Name"),
                Name = name
            };

            return View(viewModel);
        }
    }
}
