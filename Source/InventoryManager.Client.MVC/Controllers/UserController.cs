using InventoryManager.Client.MVC.Models.UserViewModels;
using InventoryManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Client.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var userFromDatabase = this.userService.GetAllUsers();
            var viewModel = new List<AllUsersViewModel>();

            foreach (var user in userFromDatabase)
            {
                var currentUser = new AllUsersViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    UserName = user.UserName
                };

                viewModel.Add(currentUser);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var userModel = this.userService
                                .GetUsersByUserName(search);

            var viewModel = new List<AllUsersViewModel>();

            foreach (var user in userModel)
            {
                var currentUser = new AllUsersViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName
                };

                viewModel.Add(currentUser);
            }

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllUsers", viewModel);
        }
    }
}