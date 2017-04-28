using InventoryManager.Client.MVC.Models.ClothesViewModels;
using InventoryManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Client.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClothesService clothesService;

        public HomeController(IClothesService clothesService)
        {
            this.clothesService = clothesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clothesFromDatabase = this.clothesService.GetAllClothes();
            var viewModel = new List<AllClothesViewModel>();

            foreach (var clothes in clothesFromDatabase)
            {
                var currentClothes = new AllClothesViewModel()
                {
                    Id = clothes.Id,
                    Name = clothes.Name,
                    Price = clothes.Price,
                    Quantity = clothes.Quantity,
                    Type = clothes.Type
                };

                viewModel.Add(currentClothes);
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}