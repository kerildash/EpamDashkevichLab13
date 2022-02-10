using EpamDashkevichLab13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EpamDashkevichLab13.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EpamDashkevichLab13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemsRepository repository;

        public HomeController(ItemsRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var model = repository.GetItems();
            return View(model);
        }
        public IActionResult ItemsEdit(int id)
        {
            Item model = id == default ? new Item() : repository.GetItemById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult ItemsEdit(Item model)
        {
            if (ModelState.IsValid)
            {
                repository.SaveItem(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult ItemsDelete(int id)
        {
            repository.RemoveItem(new Item { Id = id });
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
