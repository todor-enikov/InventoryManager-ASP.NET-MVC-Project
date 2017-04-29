using InventoryManager.Auth;
using InventoryManager.Client.MVC.Models.UserViewModels;
using InventoryManager.Common;
using InventoryManager.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private readonly IRoleService roleService;

        private UserManager userManager;

        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
            UserManager = userManager;
        }

        //public UserController(UserManager userManager)
        //{
        //    UserManager = userManager;
        //}

        public UserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public ActionResult Details(string id)
        {
            var userById = this.userService
                               .GetUserById(id);

            var userClothes = new List<UserClothesViewModel>();

            foreach (var clothes in userById.Clothes)
            {
                var currentClothes = new UserClothesViewModel()
                {
                    Id = clothes.Id,
                    Name = clothes.Name

                };

                userClothes.Add(currentClothes);
            }
            //var role = userById.Roles.Where(r => r.UserId == id).ToList()[0].UserId.;
            var userRole = userById.Roles.SingleOrDefault().RoleId;
            var role = roleService.GetCurrentRoleOfUser(userRole);

            var viewModel = new UserDetailsViewModel()
            {
                Id = userById.Id,
                FirstName = userById.FirstName,
                LastName = userById.LastName,
                UserName = userById.UserName,
                Email = userById.Email,
                Clothes = userClothes,
                Role = role
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Details(string id, string un)
        {
            var userById = this.userService.GetUserById(id);
            var userRole = userById.Roles.SingleOrDefault().RoleId;

            var role = roleService.GetCurrentRoleOfUser(userRole);
            if (role == ApplicationConstants.AdminRole)
            {
                UserManager.AddToRole(id, ApplicationConstants.UserRole);
                UserManager.RemoveFromRole(id, ApplicationConstants.AdminRole);
            }
            else
            {
                UserManager.AddToRole(id, ApplicationConstants.AdminRole);
                UserManager.RemoveFromRole(id, ApplicationConstants.UserRole);
            }

            return RedirectToAction("Index", "Success");
        }

        [HttpGet]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(string id)
        {
            var userById = this.userService
                               .GetUserById(id);

            var viewModel = new UserDetailsViewModel()
            {
                FirstName = userById.FirstName,
                LastName = userById.LastName,
                UserName = userById.UserName,
                Email = userById.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(UserDetailsViewModel model)
        {
            var userToUpdate = userService.GetUserById(model.Id);

            userToUpdate.FirstName = model.FirstName;
            userToUpdate.LastName = model.LastName;
            userToUpdate.UserName = model.UserName;
            userToUpdate.Email = model.Email;

            this.userService.UpdateUserInformation(userToUpdate);

            return RedirectToAction("Details", "User", new { id = model.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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