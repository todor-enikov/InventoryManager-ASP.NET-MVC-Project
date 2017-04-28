﻿using InventoryManager.Client.MVC.Models.ClothesViewModels;
using InventoryManager.Common;
using InventoryManager.Data.Models;
using InventoryManager.Services.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Client.MVC.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService clothesService;

        public ClothesController(IClothesService clothesService)
        {
            this.clothesService = clothesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddClothesViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var file = model.ImageFile;
            var imagePath = ApplicationConstants.ImagePath + file.FileName;
            this.UploadFile(file);

            var clothesToAdd = new Clothes()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Size = model.Size,
                Type = model.Type,
                ImagePath = imagePath,
                UserId = userId
            };

            this.clothesService.AddNewClothes(clothesToAdd);

            return RedirectToAction("Index", "Success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var clothesModel = this.clothesService.GetClothesByName(search);

            var viewModel = new List<AllClothesViewModel>();

            foreach (var clothes in clothesModel)
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

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllClothes", viewModel);
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                     || Path.GetExtension(file.FileName).ToLower() == ".jpeg"
                     || Path.GetExtension(file.FileName).ToLower() == ".png"
                     || Path.GetExtension(file.FileName).ToLower() == ".gif")
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath(ApplicationConstants.ImagePath), fileName);
                        file.SaveAs(path);
                    }
                }
            }
        }
    }
}