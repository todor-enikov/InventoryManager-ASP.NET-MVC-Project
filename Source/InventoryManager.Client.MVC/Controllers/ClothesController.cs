using InventoryManager.Client.MVC.Models.ClothesViewModels;
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

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var clothesById = this.clothesService.GetClothesById(id);

            var viewModel = new ClothesDetailsViewModel()
            {
                Id = clothesById.Id,
                Name = clothesById.Name,
                Description = clothesById.Description,
                ImagePath = clothesById.ImagePath,
                Price = clothesById.Price,
                Quantity = clothesById.Quantity,
                Size = clothesById.Size,
                Type = clothesById.Type,
                CreatedByUser = clothesById.User.UserName
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(Guid id)
        {
            var clothesById = this.clothesService.GetClothesById(id);

            var viewModel = new EditClothesViewModel()
            {
                Id = clothesById.Id,
                Name = clothesById.Name,
                Description = clothesById.Description,
                Price = clothesById.Price,
                Quantity = clothesById.Quantity,
                Size = clothesById.Size,
                Type = clothesById.Type
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(EditClothesViewModel model)
        {
            var clothesToUpdate = this.clothesService.GetClothesById(model.Id);

            var userId = User.Identity.GetUserId();
            var file = model.ImageFile;
            this.UploadFile(file);

            if (file != null)
            {
                var imagePath = ApplicationConstants.ImagePath + file.FileName;
                clothesToUpdate.ImagePath = imagePath;
            }

            clothesToUpdate.Name = model.Name;
            clothesToUpdate.Description = model.Description;
            clothesToUpdate.Price = model.Price;
            clothesToUpdate.Quantity = model.Quantity;
            clothesToUpdate.Size = model.Size;
            clothesToUpdate.Type = model.Type;
            clothesToUpdate.UserId = userId;

            this.clothesService.UpdateClothesInformation(clothesToUpdate);

            return RedirectToAction("Details", "Clothes", new { id = model.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Delete(Guid id)
        {
            this.clothesService.DeleteClothes(id);

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