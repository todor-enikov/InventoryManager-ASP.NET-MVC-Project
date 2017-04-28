using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Client.MVC.Models.UserViewModels
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 5)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 5)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Index(IsUnique =true)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public List<UserClothesViewModel> Clothes { get; set; }
    }
}