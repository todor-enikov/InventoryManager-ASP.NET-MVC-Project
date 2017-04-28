using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManager.Client.MVC.Models.UserViewModels
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public List<UserClothesViewModel> Clothes { get; set; }
    }
}