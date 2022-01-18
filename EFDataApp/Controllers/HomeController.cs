using EFDataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Controllers
{
    public class HomeController : Controller
    {
        private Models.AppContext _appContext;
        public HomeController(Models.AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appContext.Users.ToListAsync()); //получаем элементы из бд
        }

        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _appContext.Users.Add(user);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await _appContext.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await _appContext.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _appContext.Users.Update(user);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
